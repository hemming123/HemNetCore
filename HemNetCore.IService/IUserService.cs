using HemNetCore.IService.Base;
using HemNetCore.Model;
using HemNetCore.Model.Enity;
using HemNetCore.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HemNetCore.IService
{
    public interface IUserService : IBaseService<Kernel_User>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        Task<ResultModel<List<UserViewModel>>> GetUserAllList(Guid id);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<ResultModel<PagedModel<UserViewModel>>> GetUserPage(int page, int pageSize);


        ///// <summary>
        ///// 获取用户信息
        ///// </summary>
        ///// <param name="userID"></param>
        ///// <returns></returns>
        //Task<Kernel_User> GetUser(Guid userID);

        /// <summary>
        /// 获取用户会话信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserSessionVModel GetUserSession(Guid userId);

    }
}
