using HemNetCore.WebAPI.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HemNetCore.WebAPI.SetUp
{
    /// <summary>
    /// 自定义用来注册Swagger文档类
    /// </summary>
    public static class SwaggerSetup
    {
        /// <summary>
        /// 注册Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerSetup(this IServiceCollection services) {

            if (services == null) throw new ArgumentNullException(nameof(services));

           // {ApiName} 定义成全局变量，方便修改
            var ApiName = "HemNetCore.API";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Description = $"{ApiName} HTTP API V1",
                    Title = $"{ApiName} 接口文档——Netcore3.1",
                });
                c.OrderActionsBy(o => o.RelativePath);

                //获取xml注释文件目录
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "HemNetCore.WebAPI.xml");
                //默认的第二个参数是false，这个是controller的注释
                c.IncludeXmlComments(xmlPath, true);

                var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "HemNetCore.Model.xml");
                c.IncludeXmlComments(xmlModelPath, true);

                //添加身份验证
                c.OperationFilter<TokenAuthorizeFilter>();
            });
        }
    } 
}
