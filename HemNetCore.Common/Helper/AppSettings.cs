using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HemNetCore.Common.Helper
{
    /// <summary>
    /// AppSettings.json操作类
    /// </summary>
    public class AppSettings
    {
        public static IConfiguration Configuration { get;set; }

        //public AppSettings(string contentPath)
        //{
        //    string Path = "appsettings.json";
        //    //如果你把配置文件 是 根据环境变量来分开了，可以这样写
        //    //Path = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
        //    //可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
        //    Configuration = new ConfigurationBuilder().SetBasePath(contentPath).Add(new JsonConfigurationSource { Path = Path, Optional = false, ReloadOnChange = true }).Build();
        //}

        //public AppSettings(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}


        static AppSettings()
        {
            string Path = "appsettings.json";
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = Path, ReloadOnChange = true })
            .Build();
        }


        #region 获取配置文件信息
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static string DbConnectionString => Configuration["DbConnection:ConnectionString"];
        //{
        //    get
        //    {
        //        return Configuration["DbConnection:ConnectionString"];
        //    }
        //}

        /// <summary>
        /// 获取RedisCache连接字符串
        /// </summary>
        public static string RedisCacheConnectionString => Configuration["RedisServer:Cache"];
        //{

        //    get
        //    {
        //        return Configuration["RedisServer:Cache"];
        //    }
        //}

        /// <summary>
        /// 获取RedisSequence连接字符串
        /// </summary>
        public static string RedisSequenceConnectionString => Configuration["RedisServer:Sequence"];
        //{

        //    get
        //    {
        //        return Configuration["RedisServer:Sequence"];
        //    }
        //}

        /// <summary>
        /// 获取RedisSession连接字符串
        /// </summary>
        public static string RedisSessionConnectionString => Configuration["RedisServer:Session"];
        //{

        //    get
        //    {
        //        return Configuration["RedisServer:Session"];
        //    }
        //}
        #endregion

        #region 封装配置文件
        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception) { }

            return string.Empty;
        }


        /// <summary>
        /// 递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> app<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }

        #endregion
    }
}
