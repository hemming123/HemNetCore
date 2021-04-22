using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using HemNetCore.WebAPI.SetUp;
using HemNetCore.Common.Helper;
using HemNetCore.Repository.Sugar;
using HemNetCore.IService;
using HemNetCore.Service;
using HemNetCore.Repository;
using HemNetCore.Repository.Base;
using HemNetCore.Model.Enity;
using HemNetCore.WebAPI.Extensions;
using HemNetCore.Common.Redis;

namespace HemNetCore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        //运行时调用此方法。使用此方法向容器添加服务。
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //注册appSettings读取类
            // services.AddSingleton(new AppSettings(Configuration));

            //注册服务类
 
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IBaseRepository<Kernel_User>,BaseRepository<Kernel_User>>();
            services.AddSingleton<IMemberService, MemberService>();
            services.AddSingleton<IBaseRepository<Kernel_Member>, BaseRepository<Kernel_Member>>();
            // services.AddSingleton<IUserRepository, UserRepository>();

            //注册Session
            services.AddSingleton<SessionManager>();

            //注入缓存
            services.AddMemoryCache();

            //注入 HTTPCONTEXT
            services.AddHttpContextAccessor();

            //注册Swagger
            services.AddSwaggerSetup();

            services.AddControllers();

            //注册REDIS 服务
            RedisServer.Initalize();
        }

        /// <summary>
        ///运行时调用此方法。使用此方法配置HTTP请求管道。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", "HemNetCoreAPI V1");
                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
