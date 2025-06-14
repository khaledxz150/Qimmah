using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Qimmah.Data;

namespace Qimmah.Managers
{
    public class CacheManagers
    {
        private readonly IServiceProvider _services;
        private readonly IMemoryCache _memoryCache;

        private readonly TimeSpan _refreshInterval = TimeSpan.FromHours(1);
        private Timer _timer;

        public CacheManagers(IServiceProvider services, IMemoryCache memoryCache)
        {
            _services = services;
            _memoryCache = memoryCache;
        }

        public void StartLocalizationCacheRefresh()
        {
            _timer = new Timer(async _ => await CacheLocalization(), null, TimeSpan.Zero, _refreshInterval);
        }

        internal async Task CacheLanguages()
        {
            using var scope = _services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            _memoryCache.Set("Languages", await dbContext.Languages.ToListAsync(), _refreshInterval);

        }

        private async Task CacheLocalization()
        {
            using var scope = _services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var localizations = await dbContext.DictionaryLocalization
                .Include(c => c.Dictionary)
                .Include(c => c.Language)
                .ToListAsync();

            var groupedDictionary = localizations
                .GroupBy(l => l.LanguageID)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToDictionary(x => x.ID, x => x.Description)
                );

            _memoryCache.Set("DictionaryLocalizationCache", groupedDictionary, _refreshInterval);
        }
    }
}
