using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

using System.Security.Claims;

namespace Qimmah.Helpers;
public static class DictionaryLocalizationHelper
{
    public static string GetWord(this IHtmlHelper htmlHelper, int dictionaryId)
    {
        var httpContext = htmlHelper.ViewContext.HttpContext;

        // Retrieve memory cache service
        var memoryCache = httpContext.RequestServices.GetRequiredService<IMemoryCache>();

        int languageId = 2; // Default language ID

        // Try to get from user claims if user is authenticated
        var user = httpContext.User;
        if (user?.Identity?.IsAuthenticated == true)
        {
            var languageIdClaim = user.FindFirst("LanguageID")?.Value;
            if (!string.IsNullOrWhiteSpace(languageIdClaim) && int.TryParse(languageIdClaim, out var parsedFromClaim))
            {
                languageId = parsedFromClaim;
            }
        }
        else if (httpContext.Request.Headers.TryGetValue("LanguageID", out var langHeader))
        {
            if (int.TryParse(langHeader.ToString(), out var parsedFromHeader))
            {
                languageId = parsedFromHeader;
            }
        }

        // Try retrieving from the cache
        if (memoryCache.TryGetValue("DictionaryLocalizationCache", out Dictionary<int, Dictionary<int, string>> allLocalizations))
        {
            if (allLocalizations.TryGetValue(languageId, out var localizationsForLanguage))
            {
                if (localizationsForLanguage.TryGetValue(dictionaryId, out var text))
                {
                    return text;
                }
            }
        }

        return $"[Missing:{dictionaryId}]";
    }

}
