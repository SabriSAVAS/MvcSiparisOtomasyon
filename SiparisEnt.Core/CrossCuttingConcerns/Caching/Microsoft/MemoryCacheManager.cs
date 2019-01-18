using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }
        public void Add(string key, object data, int cacheTime=60)
        {
            if (data==null)
            {
                return;
            }
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) };
            Cache.Add(new CacheItem(key, data), policy);
        }

       

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Cache.Remove(item.Key);
            }
        }
        public void RemoveByPattern(string pattern)
        {
            var regax = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(x => regax.IsMatch(x.Key)).Select(x => x.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Cache.Remove(key);
            }
        }
    }
}