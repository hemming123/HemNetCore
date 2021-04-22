using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HemNetCore.Model;

namespace HemNetCore.WebAPI.Controllers
{
    /// <summary>
    /// 自定义路由模版
    /// 用于解决swagger文档No operations defined in spec!问题
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        #region 返回统一封装

        /// <summary>
        /// 返回统一JSON
        /// </summary>
        /// <param name="retsultModel"></param>
        /// <returns></returns>
        public static JsonResult ToResponseJson(object retsultModel)
        {
            return new JsonResult(retsultModel);
        }
        #endregion
    }
}
