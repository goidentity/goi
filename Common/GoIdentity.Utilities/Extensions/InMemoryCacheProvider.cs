using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace GoIdentity.Utilities.Extensions
{
    public class InMemoryCacheProvider : ICacheManager
    {
        private readonly MemoryCache cacheClient;
        public InMemoryCacheProvider()
        {
            this.cacheClient = System.Runtime.Caching.MemoryCache.Default;
        }
        private string GetKey(short organizationId, string key)
        {
            return string.Format("{0}_{1}", key, organizationId);
        }

        public void Add<T>(short organizationId, string key, T value)
        {
            this.cacheClient.Add(GetKey(organizationId, key), value, new CacheItemPolicy { SlidingExpiration = new TimeSpan(240, 0, 0) });
        }

        public void Add<T>(short organizationId, string key, T value, DateTime expiresAt)
        {
            this.cacheClient.Add(GetKey(organizationId, key), value, new CacheItemPolicy { SlidingExpiration = new TimeSpan(240, 0, 0) });
        }
        public void Add<T>(short organizationId, string key, T value, TimeSpan expiresIn)
        {
            this.cacheClient.Add(GetKey(organizationId, key), value, new CacheItemPolicy { SlidingExpiration = expiresIn });
        }

        public void FlushAll()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(short organizationId, string key)
        {
            var obj = this.cacheClient.Get(GetKey(organizationId, key));

            if (obj != null) return (T)obj;
            else return default(T);
        }
        public IDictionary<string, T> GetAll<T>(short organizationId, IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }
        public void Remove(short organizationId, string key)
        {
            this.cacheClient.Remove(GetKey(organizationId, key));
        }
        public void RemoveAll(short organizationId, IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }
        public void SetAll<T>(short organizationId, IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }
    }
}
