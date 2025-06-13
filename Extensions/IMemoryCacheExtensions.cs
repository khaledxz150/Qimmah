
using Microsoft.Extensions.Caching.Memory;

namespace Qimmah.Extensions;
public static class IMemoryCacheExtensions
{
    public static string GetWord(int DictionaryID)
    {
        var httpContext = new HttpContextAccessor().HttpContext;
        if (httpContext == null)
        {
            return "-"; // No HttpContext available
        }

        // Retrieve memory cache service
        var memoryCache = httpContext.RequestServices.GetRequiredService<IMemoryCache>();

        // Try retrieving from the cache
        if (memoryCache.TryGetValue("DictionaryLocalizationCache", out Dictionary<int, Dictionary<int, string>> allLocalizations))
        {
            foreach (var localizationsForLanguage in allLocalizations.Values)
            {
                if (localizationsForLanguage.TryGetValue(DictionaryID, out string word))
                {
                    return word; // Word found in cache
                }
            }
        }

        return "-";
    }

    
        
}
