using HemNetCore.IService;
using HemNetCore.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HemNetCore.Common.Utils;
using HemNetCore.Common.Redis;
using HemNetCore.Model;
using HemNetCore.Model.Enum;
using HemNetCore.Model.Dto;

namespace HemNetCore.WebAPI.Controllers
{
    /// <summary>
    /// 用户认证
    /// </summary>
    public class AuthController : BaseController
    {
        /// <summary>
        /// 回话接口
        /// </summary>
        public readonly SessionManager _sessionManager;
        private readonly IUserService _userService;

        public AuthController(SessionManager sessionManager, IUserService userService)
        {
            _sessionManager = sessionManager;
            _userService = userService;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult VerifiyCode()
        {
            var verificationCode = VerificationCodeUtil.GenerateRandomCode();
            var verificationImage = VerificationCodeUtil.GenerateCodeImage(verificationCode);
            //验证码存入缓存
            RedisServer.Cache.Set($"VerificationCode:{verificationImage.VerificationUUID}", verificationCode, 1800);
            var resultData = new
            {
                VerificationCode = $"data:image/png;base64,{Convert.ToBase64String(verificationImage.CaptchaMemoryStream.ToArray())}",
                VerificationUuid = verificationImage.VerificationUUID
            };
            return ToResponseJson(ResultModel<object>.Ok(resultData));
        }

        /// <summary>
        /// 后台用户登录
        /// </summary>
        /// <returns></returns>
       [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto parm)
        {
            //获取缓存验证码
            var verificationCode = RedisServer.Cache.Get($"VerificationCode:{parm.UUID}");
            //删除缓存
            RedisServer.Cache.Del($"VerificationCode:{parm.UUID}");
            if (parm.VerificationCode.ToUpper() != verificationCode)
            {
                return ToResponseJson(ResultModel<string>.Fail("验证码无效"));
            }
            var userInfo = await _userService.QuerySingle(t => t.LoginName == parm.LoginName && t.UserType == UserType.Admin && !t.Deleted);
            if (userInfo == null)
            {
                return ToResponseJson(ResultModel<string>.Fail("用户名或密码错误"));
            }
            //验证密码
            var isPassword = !PasswordUtil.ComparePasswords(userInfo.ID.ToString(), userInfo.Password, parm.PassWord.Trim());
            if (isPassword)
            {
                return ToResponseJson(ResultModel<string>.Fail("用户名或密码错误"));
            }
            //创建用户Session
            var userSession = _sessionManager.Create(userInfo, 24);
            return ToResponseJson(ResultModel<string>.Ok(userSession, HttpStatusCode.Success));
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LogOut()
        {
            _sessionManager.Remove(_sessionManager.SysToken);
            return ToResponseJson(ResultModel<bool>.Ok());
        }
    }
}
