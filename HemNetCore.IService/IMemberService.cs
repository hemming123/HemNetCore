using HemNetCore.IService.Base;
using HemNetCore.Model;
using HemNetCore.Model.Dto;
using HemNetCore.Model.Enity;
using HemNetCore.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HemNetCore.IService
{
    public interface IMemberService : IBaseService<Kernel_Member>
    {
        /// <summary>
        /// 获取会员分页数据
        /// </summary>
        /// <returns></returns>
        Task<ResultModel<PagedModel<MemberVModel>>> GetMemberPage(MemberDto parm);
    }
}
