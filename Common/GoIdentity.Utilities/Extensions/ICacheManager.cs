using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Utilities.Extensions
{
    internal interface ICacheManager
    {
        void Add<T>(short organizationId, string key, T value);
        void Add<T>(short organizationId, string key, T value, DateTime expiresAt);
        void Add<T>(short organizationId, string key, T value, TimeSpan expiresIn);
        void FlushAll();
        T Get<T>(short organizationId, string key);
        //T Contains<T>(short organizationId, string key);
        IDictionary<string, T> GetAll<T>(short organizationId, IEnumerable<string> keys);
        void Remove(short organizationId, string key);
        void RemoveAll(short organizationId, IEnumerable<string> keys);
        void SetAll<T>(short organizationId, IDictionary<string, T> values);
    }
}
