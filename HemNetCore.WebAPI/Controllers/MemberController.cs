using HemNetCore.IService;
using HemNetCore.Model;
using HemNetCore.Model.Dto;
using HemNetCore.Model.ViewModel;
using HemNetCore.WebAPI.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HemNetCore.WebAPI.Controllers
{
    /// <summary>
    /// 会员管理
    /// </summary>
    public class MemberController : BaseController
    {
        private readonly IMemberService _memberSerice;
        public MemberController(IMemberService memberService)
        {
            _memberSerice = memberService;
        }

        /// <summary>
        /// 查询会员分页数据
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorization]
        public async Task<IActionResult> QueryPage([FromBody] MemberDto parm)
        {
            var result = await _memberSerice.GetMemberPage(parm);
            return ToResponseJson(result);
        }
    }
}
