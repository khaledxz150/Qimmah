using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Qimmah.Data;
using Qimmah.Data.System;
using Qimmah.Enums.System;
using Qimmah.Models.Common;
using Qimmah.Security;

namespace Qimmah.Application.System;

public class LookupService : Core.System.ILookupService
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _cache;

    public LookupService(ApplicationDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }
    public async Task<Lookup> GetLookupByIdAsync(int id)
    {
        return await _context.Lookups.FindAsync(id);
    }
    public async Task<Lookup> GetLookupByCategoryAndIdAsync(int categoryId, int id)
    {
        return await _context.Lookups
            .FirstOrDefaultAsync(l => l.CategoryID == categoryId && l.ID == id);
    }
    public async Task<List<Lookup>> GetLookupsByCategoryAsync(int categoryId)
    {
        return await _context.Lookups
            .Where(l => l.CategoryID == categoryId)
            .ToListAsync();
    }
    public async Task<List<DDLViewModel>> GetLookupsAsDDLAsync(LookupCategoryEnum categoryEnum, int languageId = 2)
    {
        string cacheKey = $"ddl_{categoryEnum}_{languageId}";

        if (!_cache.TryGetValue(cacheKey, out List<DDLViewModel> cachedList))
        {
            cachedList = await _context.Lookups
                .Where(l => l.CategoryID == categoryEnum.ToAnyType<int>()).AsNoTracking()
                .Include(l => l.Dictionary).AsSplitQuery()
                .Select(l => new DDLViewModel
                {
                    Value = l.ID.Encrypt(),
                    Text = l.Dictionary.DictionaryLocalization
                        .Where(x => x.LanguageID == languageId)
                        .Select(dl => dl.Description)
                        .FirstOrDefault()
                })
                .ToListAsync();

            // Optional: configure cache options
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));

            _cache.Set(cacheKey, cachedList, cacheEntryOptions);
        }

        return cachedList;
    }


}
