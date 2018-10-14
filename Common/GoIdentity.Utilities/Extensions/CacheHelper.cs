using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Utilities.Extensions
{
    public static class CacheManager
    {
        private static object syncObject = new object();
        private static ICacheManager _cacheManager = default(ICacheManager);
        static CacheManager()
        {
#if DEBUG
            _cacheManager = new InMemoryCacheProvider();
#else
            _cacheManager = new InMemoryCacheProvider();
#endif
        }

        public static void Add<T>(short organizationId, string key, T value)
        {
            _cacheManager.Add<T>(organizationId, key, value);
        }
        public static void Add<T>(short organizationId, string key, T value, TimeSpan absoluteExpiration)
        {
            _cacheManager.Add<T>(organizationId, key, value, absoluteExpiration);
        }
        public static T Get<T>(short organizationId, string key) where T : class
        {
            return _cacheManager.Get<T>(organizationId, key);
        }
        //public static T Contains<T>(short organizationId, string key) where T:class
        //{
        //    return _cacheManager.Contains<T>(organizationId,key);
        //}
        public static bool IsExists<T>(short organizationId, string key)
        {
            return _cacheManager.Get<T>(organizationId, key) != null ? true : false;
        }
        public static void Remove(short organizationId, string key)
        {
            _cacheManager.Remove(organizationId, key);
        }
        public static void Flush()
        {
            _cacheManager.FlushAll();
        }
    }
}
