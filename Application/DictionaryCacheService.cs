using Microsoft.Extensions.Caching.Memory;
using Qimmah.Core;

namespace Qimmah.Application
{
    public class DictionaryCacheService<TKey, TValue> : IDictionaryCacheService<TKey, TValue>
    {
        private readonly IMemoryCache _memoryCache;

        public DictionaryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Dictionary<TKey, TValue> GetOrCreate(string cacheKey, Func<Dictionary<TKey, TValue>> factory, TimeSpan? absoluteExpiration = null)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out Dictionary<TKey, TValue> value))
            {
                value = factory();

                var cacheEntryOptions = new MemoryCacheEntryOptions();
                if (absoluteExpiration.HasValue)
                    cacheEntryOptions.SetAbsoluteExpiration(absoluteExpiration.Value);

                _memoryCache.Set(cacheKey, value, cacheEntryOptions);
            }

            return value;
        }

        public void Set(string cacheKey, Dictionary<TKey, TValue> value, TimeSpan? absoluteExpiration = null)
        {
            var options = new MemoryCacheEntryOptions();
            if (absoluteExpiration.HasValue)
                options.SetAbsoluteExpiration(absoluteExpiration.Value);

            _memoryCache.Set(cacheKey, value, options);
        }

        public bool TryGet(string cacheKey, out Dictionary<TKey, TValue> value)
        {
            return _memoryCache.TryGetValue(cacheKey, out value);
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }

}
