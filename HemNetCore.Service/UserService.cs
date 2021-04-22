using System;
using HemNetCore.Common.Helper;
using HemNetCore.IService.Base;
using HemNetCore.IService;
using HemNetCore.Model.ViewModel;
using HemNetCore.Model.Enity;
using HemNetCore.Service.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using HemNetCore.Model;
using SqlSugar;
using System.Linq.Expressions;
using HemNetCore.Repository.Base;
using System.Linq;

namespace HemNetCore.Service
{
    public class UserService :BaseService<Kernel_User>, IUserService
    {
        private readonly IBaseRepository<Kernel_User> baseDal;
        public UserService(IBaseRepository<Kernel_User> baseserviceDal):base(baseserviceDal)
        {
            baseDal = baseserviceDal;
        }

        public async Task<ResultModel<List<UserViewModel>>> GetUserAllList(Guid id)
        {
            var result = await baseDal.QueryMuch<Kernel_User, Kernel_Member, UserViewModel>(
                (u, m) => new object[] { JoinType.Left, u.ID == m.UserId },
                (u, m) => new UserViewModel
                {
                    UserId = u.ID,
                    Address = "南京大数据产业基地4栋101",
                    Phone = u.LoginName,
                    UserName = u.Name
                },(u, m) => u.ID == id);
            return ResultModel<List<UserViewModel>>.Ok(result);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<ResultModel<PagedModel<UserViewModel>>> GetUserPage(int page, int pageSize)
        {
            Expression<Func<Kernel_User, Kernel_Member, object[]>> joinExpression = (u, m) => new object[] { JoinType.Left, u.ID == m.UserId };
            Expression<Func<Kernel_User, Kernel_Member, UserViewModel>> selectEpression = (u, m) => new UserViewModel
            {
                UserId = u.ID,
                Address = "南京大数据产业基地4栋101",
                Phone = u.LoginName,
                UserName = u.Name
            };
            var result = await baseDal.QueryTabsPage(joinExpression, selectEpression,null, page, pageSize, "UserId asc");
            return ResultModel<PagedModel<UserViewModel>>.Ok(result);
        }

        /// <summary>
        /// 获取用户Session
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserSessionVModel GetUserSession(Guid userId)
        {
            var userInfo = baseDal.QueryMuch<Kernel_User, Kernel_Admin, Kernel_Partner, Kernel_Role, UserSessionVModel>(
                (u, a, p, r) => new object[] { JoinType.Left, u.ID == a.UserId, JoinType.Left, u.PartnerID == p.ID, JoinType.Left, a.RoleId == r.ID },
                (u, a, p, r) => new UserSessionVModel
                {
                    UserId = a.UserId,
                    StoreId = a.StoreID,
                    RoleId = a.RoleId.Value,
                    PartnerId = a.PartnerId,
                    OrganizationID = r.OrganizationID,
                    IsEjz = r.IsEjz,
                    UserName = u.Name,
                    Level = p.Level,
                    IsAdministrator = r.IsAdministrator.Value,
                    LoginName = u.LoginName.Trim(),
                    Password = u.Password.Trim(),
                    OperatorTime = DateTime.Now
                },
                (u, a, p, r) => u.ID == userId && !r.IsDeleted.Value);

            return userInfo.Result.FirstOrDefault();
        }
    }
}
