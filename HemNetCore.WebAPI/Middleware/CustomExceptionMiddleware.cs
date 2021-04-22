using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HemNetCore.WebAPI.Middleware
{
    /// <summary>
    /// 自定义消息返回过滤中间件
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next) {

            _next = next;
        }
    }
}
