using System;
using System.Web;

namespace TravelAgent.Tool
{
    public static class CacheHelper
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T">缓存类型</typeparam>
        /// <param name="key">缓存键值</param>
        /// <param name="o">缓存对象</param>
        public static void Add<T>(string key, T o)
        {
            HttpContext.Current.Cache.Insert(key,
                o,
                null,
                DateTime.Now.AddMinutes(60),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键值</param>
        public static void Clear(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// 缓存是否存在
        /// </summary>
        /// <param name="key">缓存键值</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">缓存类型</typeparam>
        /// <param name="key">缓存键值</param>
        /// <param name="value">返回缓存对象</param>
        /// <returns>返回缓存对象</returns>
        public static T Get<T>(string key)
        {
            T value;

            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                }
                value = (T)HttpContext.Current.Cache[key];
            }
            catch
            {
                value = default(T);
            }
            return value;
        }
    }
}

