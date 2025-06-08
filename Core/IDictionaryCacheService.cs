namespace Qimmah.Core
{
    public interface IDictionaryCacheService<TKey, TValue>
    {
        Dictionary<TKey, TValue> GetOrCreate(string cacheKey, Func<Dictionary<TKey, TValue>> factory, TimeSpan? absoluteExpiration = null);
        void Set(string cacheKey, Dictionary<TKey, TValue> value, TimeSpan? absoluteExpiration = null);
        bool TryGet(string cacheKey, out Dictionary<TKey, TValue> value);
        void Remove(string cacheKey);
    }
}
