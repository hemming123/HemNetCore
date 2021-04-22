using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.ComponentModel;

namespace HemNetCore.Model.Enum
{
    public enum HttpStatusCode
    {
        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Description("请求(或处理)成功")]
        Success = 200,

        /// <summary>
        /// 内部请求出错
        /// </summary>
        [Description("内部请求出错")]
        Error = 500,

        /// <summary>
        /// 访问请求未授权! 当前 SESSION 失效, 请重新登录
        /// </summary>
        [Description("访问请求未授权! 当前 SESSION 失效, 请重新登录")]
        Unauthorized = 401,

        /// <summary>
        /// 请求参数不完整或不正确
        /// </summary>
        [Description("请求参数不完整或不正确")]
        ParameterError = 400,

        /// <summary>
        /// 您无权进行此操作，请求执行已拒绝
        /// </summary>
        [Description("您无权进行此操作，请求执行已拒绝")]
        Forbidden = 403,

        /// <summary>
        /// 找不到与请求匹配的 HTTP 资源
        /// </summary>
        [Description("找不到与请求匹配的 HTTP 资源")]
        NotFound = 404,

        /// <summary>
        /// HTTP请求类型不合法
        /// </summary>
        [Description("HTTP请求类型不合法")]
        HttpMehtodError = 405,

        /// <summary>
        /// HTTP请求不合法,请求参数可能被篡改
        /// </summary>
        [Description("HTTP请求不合法,请求参数可能被篡改")]
        HttpRequestError = 406,

        /// <summary>
        /// 该URL已经失效
        /// </summary>
        [Description("该URL已经失效")]
        URLExpireError = 407,
    }
}
