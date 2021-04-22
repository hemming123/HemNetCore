using CSRedis;
using System;
using System.Collections.Generic;
using System.Text;
using HemNetCore.Common.Helper;

namespace HemNetCore.Common.Redis
{
    public static class RedisServer
    {
        /// <summary>
        /// 缓存
        /// </summary>
        public static CSRedisClient Cache;

        /// <summary>
        /// 队列
        /// </summary>
        public static CSRedisClient Sequence;

        /// <summary>
        /// 回话
        /// </summary>
        public static CSRedisClient Session;
         
        public static void Initalize()
        {
            Cache = new CSRedisClient(AppSettings.RedisCacheConnectionString);
            Sequence = new CSRedisClient(AppSettings.RedisSequenceConnectionString);
            Session = new CSRedisClient(AppSettings.RedisSessionConnectionString);
        }
    }
}
