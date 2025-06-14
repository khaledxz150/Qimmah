
using Microsoft.Extensions.Caching.Memory;

using Qimmah.Data.Localization;

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
           if (allLocalizations[GetLanguageIdFromLocalCookie()].TryGetValue(DictionaryID, out string word))
           {
               return word; 
           }
        }

        return "-";
    }


    public static List<Languages> GetLanguagesFromCache(this IMemoryCache memoryCache)
    {
        if (memoryCache.TryGetValue("Languages", out List<Languages> languages))
        {
            return languages;
        }
        return new List<Languages>();
    }



}
