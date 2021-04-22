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

        //����ʱ���ô˷�����ʹ�ô˷�����������ӷ���
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ע��appSettings��ȡ��
            // services.AddSingleton(new AppSettings(Configuration));

            //ע�������
 
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IBaseRepository<Kernel_User>,BaseRepository<Kernel_User>>();
            services.AddSingleton<IMemberService, MemberService>();
            services.AddSingleton<IBaseRepository<Kernel_Member>, BaseRepository<Kernel_Member>>();
            // services.AddSingleton<IUserRepository, UserRepository>();

            //ע��Session
            services.AddSingleton<SessionManager>();

            //ע�뻺��
            services.AddMemoryCache();

            //ע�� HTTPCONTEXT
            services.AddHttpContextAccessor();

            //ע��Swagger
            services.AddSwaggerSetup();

            services.AddControllers();

            //ע��REDIS ����
            RedisServer.Initalize();
        }

        /// <summary>
        ///����ʱ���ô˷�����ʹ�ô˷�������HTTP����ܵ���
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
                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
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
