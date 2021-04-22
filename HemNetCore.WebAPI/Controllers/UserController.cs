using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HemNetCore.Model.Enity;
using HemNetCore.IService;
using HemNetCore.IRepository;
using HemNetCore.Common.Helper;

namespace HemNetCore.WebAPI.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {

            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> GetList(Guid id)
        {
            var result = await _userService.GetUserAllList(id);
            return ToResponseJson(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetUserPage(int page, int pageSize)
        {
            var result = await _userService.GetUserPage(page, pageSize);
            return ToResponseJson(result);
        }

        /// <summary>
        /// Hello请求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Hello(User user) {
            return Ok("Hello World");
        }
    }
}
