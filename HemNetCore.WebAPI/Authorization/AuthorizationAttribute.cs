using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HemNetCore.Model;
using HemNetCore.Model.Enum;
using HemNetCore.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace HemNetCore.WebAPI.Authorization
{
    /// <summary>
    /// 登录验证过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method,AllowMultiple =true)]
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// 权限标志
        /// </summary>
        public string Permissions { get; set; } = string.Empty;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //判断是否登录拥有身份验证权限
            var sessionManager = context.HttpContext.RequestServices.GetService<SessionManager>();
            if (!sessionManager.IsAuthenticated)
            {
                context.Result = new JsonResult(ResultModel<bool>.Fail(false, HttpStatusCode.Unauthorized));
            }
            return;

            #region 判断是否拥有权限

            #endregion
        }
    }
}
