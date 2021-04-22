using HemNetCore.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HemNetCore.Model
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class ResultModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; } = 0;

        public bool Success { get; set; } = false;

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();


        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResultModel<T> Ok(string msg ="请求数据成功")
        {
            return Message(default, true, HttpStatusCode.Success, string.IsNullOrEmpty(msg) ? HttpStatusCode.Success.GetDescription() : msg);
        }

        /// <summary>
        ///返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="httpCode">状态码</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static ResultModel<T> Ok(T data, HttpStatusCode httpCode = HttpStatusCode.Success, string msg = "")
        {
            return Message(data, true, httpCode, string.IsNullOrEmpty(msg) ? httpCode.GetDescription() : msg);
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static ResultModel<T> Fail(string msg= "请求数据失败")
        {
            return Message(default, false, HttpStatusCode.Error, string.IsNullOrEmpty(msg) ? HttpStatusCode.Error.GetDescription() : msg);
        }


        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static ResultModel<T> Fail(T data, HttpStatusCode statusCode = HttpStatusCode.Error, string msg = "")
        {
            return Message(data, false, statusCode, string.IsNullOrEmpty(msg) ? statusCode.GetDescription() : msg);
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        /// <param name="success">失败/成功</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static ResultModel<T> Message(T data, bool success, HttpStatusCode statusCode, string msg)
        {
            return new ResultModel<T>() { Msg = string.IsNullOrEmpty(msg) ? statusCode.GetDescription() : msg, Code = (int)statusCode, Data = data, Success = success };
        }
    }
}
