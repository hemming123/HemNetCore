using HemNetCore.IService;
using HemNetCore.Model;
using HemNetCore.Model.Dto;
using HemNetCore.Model.Enity;
using HemNetCore.Model.ViewModel;
using HemNetCore.Repository.Base;
using HemNetCore.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using HemNetCore.Model.Enum;

namespace HemNetCore.Service
{
    /// <summary>
    /// 会员管理
    /// </summary>
    public class MemberService:BaseService<Kernel_Member>,IMemberService
    {
        private readonly IBaseRepository<Kernel_Member> baseDal;
        public MemberService(IBaseRepository<Kernel_Member> baseRepository) : base(baseRepository)
        {
            baseDal = baseRepository;
        }

        /// <summary>
        /// 获取会员分页信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public async Task<ResultModel<PagedModel<MemberVModel>>> GetMemberPage(MemberDto parm)
        {
            //拼装查询条件
            var predicate = Expressionable.Create<Kernel_Member, Kernel_User, Kernel_Partner>();
            predicate.AndIF(true, (m, u, p) => !u.Deleted && u.UserType == UserType.Member);
            predicate.AndIF(!string.IsNullOrEmpty(parm.LoginName), (m, u, p) => u.LoginName == parm.LoginName);
            predicate.AndIF(!string.IsNullOrEmpty(parm.UserName), (m, u, p) => u.Name == parm.UserName);
            var result = await baseDal.QueryTabsPage(
                (m, u, p) => new object[] { JoinType.Inner, m.UserId == u.ID, JoinType.Left, m.PartnerId == p.ID },
                (m, u, p) => new MemberVModel
                {
                    MemberID = m.ID,
                    LoginLastTime = u.LastLoginTime,
                    LoginName = u.LoginName,
                    PartnerName = p.PartnerName,
                    Sex = u.Gender,
                    UserName = u.Name,
                    VIPExpirationTime = m.VIPActiveTime
                },
                predicate.ToExpression(), parm.PageIndex, parm.PageSize, $" {parm.OrderBy} {parm.Sort} ");
            return ResultModel<PagedModel<MemberVModel>>.Ok(result);
        }
    }
}
