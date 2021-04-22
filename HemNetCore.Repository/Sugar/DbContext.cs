using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using HemNetCore.Common.Helper;
using System.Linq;

namespace HemNetCore.Repository.Sugar
{
    public class DbContext<T> where T : class, new()
    {
        /// <summary>
        /// 不能是静态变量，用来处理事务多表查询和复杂的操作
        /// </summary>
        public SqlSugarClient Db;

        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = AppSettings.DbConnectionString, //数据库连接字符串
                DbType = DbType.SqlServer, //数据库类型
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了
            });

            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +  Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

        /// <summary>
        ///用来操作当前表的数据
        /// </summary>
        public SimpleClient<T> CurrentDb
        {
            get
            {
                return new SimpleClient<T>(Db);
            }
        }
    }

}
