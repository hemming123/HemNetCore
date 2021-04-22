using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HemNetCore.Service;
using HemNetCore.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using HemNetCore.Model.Enity;
using HemNetCore.Common.Redis;
using HemNetCore.Model.ViewModel;

namespace HemNetCore.WebAPI.Extensions
{
    /// <summary>
    /// 用户会话管理
    /// </summary>
    public class SessionManager
    {
        /// <summary>
        /// 缓存组件
        /// </summary>
        private readonly IMemoryCache memoryCache;

        /// <summary>
        /// 用户接口
        /// </summary>
        public readonly IUserService userService;


        /// <summary>
        /// HTTP上下文
        /// </summary>
        private readonly IHttpContextAccessor accessor;

        public SessionManager(IHttpContextAccessor _accessor, IMemoryCache _memoryCache, IUserService _userService)
        {
            memoryCache = _memoryCache;
            accessor = _accessor;
            userService = _userService;
        }

        #region  操作Session
        /// <summary>
        /// 创建 Session
        /// </summary>
        public string Create(Kernel_User user, int hours)
        {

            //判断用户是否只允许等于一次,先清空历史session
            //if (userInfo.OneSession)
            //{
            RemoveAll(user.ID.ToString());
            // }
            var userSession = Guid.NewGuid().ToString().ToUpper();
            var expireTime = DateTime.Now.AddHours(hours);
            var timeSpan = new TimeSpan(hours, 0, 0);
            //将Session用户添加到Session缓存中
            RedisServer.Session.HSet(user.ID.ToString(), userSession, expireTime);
            RedisServer.Session.Expire(user.ID.ToString(), timeSpan);
            //获取Session 
            var userSessionModel = userService.GetUserSession(user.ID);
            //用户回话信息添加到Redis缓存中
            RedisServer.Session.HSet(userSession, "UserInfo", userSessionModel);
            RedisServer.Session.Expire(userSession, timeSpan);
            //更新登录时间
            userService.Update(u => u.ID == user.ID, u => new Kernel_User { LastLoginTime = DateTime.Now });
            return userSession;
        }

        /// <summary>
        /// 更新Session
        /// </summary>
        public void Update(string userSession)
        {
            DateTime lastUpdateTime = memoryCache.Get<DateTime>(userSession);
            if (Convert.ToDateTime(lastUpdateTime).AddMinutes(2) < DateTime.Now)
            {
                // 记录本次更新时间
                memoryCache.Set(userSession, DateTime.Now);
                if (!string.IsNullOrEmpty(userSession))
                {
                    //根据 Session 取出 UserInfo
                    var userInfo = this.GetSession<UserSessionVModel>(userSession, "UserInfo");
                    //默认3小时,正常可以从用户表里取
                    var hours = 3;
                    var expireTime = DateTime.Now.AddHours(hours);
                    var timeSpan = new TimeSpan(hours, 0, 0);

                    //更新 Session 列表中的 Session 过期时间
                    RedisServer.Session.HSet(userInfo.UserId.ToString(), userSession, expireTime);
                    //更新 Session 列表过期时间
                    RedisServer.Session.Expire(userInfo.UserId.ToString(), timeSpan);
                    //更新 Session 过期时间
                    RedisServer.Session.Expire(userSession, timeSpan);
                }
            }
        }

        /// <summary>
        /// 刷新Session
        /// </summary>
        public void Refresh(string userId) {

            if (!RedisServer.Session.Exists(userId))
            {
                return;
            }
            //取出 Session 列表所有 Key
            var keys = RedisServer.Session.HKeys(userId);

            if (keys.Length <= 0)
            {
                return;
            }
            foreach (var key in keys)
            {
                if (RedisServer.Session.Exists(key))
                {
                    //根据 Session 取出 UserInfo
                    var redisUserInfo = this.GetSession<UserSessionVModel>(key, "UserInfo");

                    //重新设置 Session 信息
                    var userSessionVM = userService.GetUserSession(Guid.Parse(userId));

                    RedisServer.Session.HSet(key, "UserInfo", userSessionVM);
                }
                else
                {
                    RedisServer.Session.HDel(userId, key);
                }
            }
        }

        /// <summary>
        /// 清除指定 Session
        /// </summary>
        public void Remove(string userSession)
        {
            if (!string.IsNullOrEmpty(userSession))
            {
                //根据 Session 删除在线用户记录
                // _onlineService.Delete(m => m.SessionID == userSession);

                if (RedisServer.Session.Exists(userSession))
                {
                    //根据 Session 取出 UserInfo
                    var userInfo = this.GetSession<UserSessionVModel>(userSession, "UserInfo");

                    //删除用户 Session 列表中的 Session
                    RedisServer.Session.HDel(userInfo.UserId.ToString(), userSession);

                    //删除 Session 
                    RedisServer.Session.Del(userSession);
                }
            }
        }

        /// <summary>
        /// 清除用户所有 Session
        /// </summary>
        public void RemoveAll(string userId)
        {
            if (RedisServer.Session.Exists(userId))
            {
                //取出 Session 列表所有 Key
                var keys = RedisServer.Session.HKeys(userId);

                foreach (var key in keys)
                {
                    //删除 Session 
                    RedisServer.Session.Del(key);

                    //删除用户 Session 列表中的 Session
                    RedisServer.Session.HDel(userId, key);
                }
            }

            //删除在线记录
            //_onlineService.Delete(m => m.UserID == userId);
        }

        #endregion

        #region 获取Session

        /// <summary>
        /// 身份验证标识（Session）
        /// </summary>
        /// <returns></returns>
        public string SysToken => accessor.HttpContext.Request.Headers["SYSTOKEN"];

        /// <summary>
        /// 当前用户登录信息
        /// </summary>
        public UserSessionVModel CurrentUserSessionInfo => this.GetSession<UserSessionVModel>("UserInfo");

        /// <summary>
        /// 是否通过身份验证
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                if (!string.IsNullOrEmpty(SysToken))
                {
                    if (!RedisServer.Session.Exists(SysToken))
                    {
                        //不存在，根据 Session 删除在线用户记录,根据业务逻辑处理
                    }
                    else
                    {
                        this.Update(SysToken);
                        return true;
                    }
                }
                return false;
            }
        }
  

        /// <summary>
        /// 获取 Session 内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetSession<T>(string key)
        {
            var isExists = !RedisServer.Session.Exists(SysToken);
            if (isExists)
            {
                throw new Exception($"GetSession : {key} has Exception");
            }
            return RedisServer.Session.HGet<T>(SysToken, key);
        }

        /// <summary>
        /// 获取 Session 内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetSession<T>(string session, string key)
        {
            var isExists = !RedisServer.Session.Exists(session);
            if (isExists)
            {
                throw new Exception($"GetSession : {key} has Exception");
            }
            return RedisServer.Session.HGet<T>(session, key);
        }
        #endregion

    }
}
