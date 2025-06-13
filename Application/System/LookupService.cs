using Microsoft.EntityFrameworkCore;
using Qimmah.Application.Security.Cryptography;
using Qimmah.Data;
using Qimmah.Data.System;
using Qimmah.Enums.System;
using Qimmah.Models.Common;

namespace Qimmah.Application.System;

public class LookupService : Core.System.ILookupService
{
    private readonly ApplicationDbContext _context;
    public LookupService(ApplicationDbContext context)
    {
        _context = context;
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
    public async Task<List<DDLViewModel>> GetLookupsAsDDLAsync(LookupCategoryEnum categoryEnum, int LanguageId = 2)
    {
        return await _context.Lookups
            .Where(l => l.CategoryID == categoryEnum.ToAnyType<int>()).AsNoTracking()
            .Include(l => l.Dictionary).AsSplitQuery()
            .Select(l => new DDLViewModel
            {
                Value = l.ID.Encrypt(),
                Text = l.Dictionary.DictionaryLocalization.Where(x => x.LanguageID == LanguageId)
                    .Select(dl => dl.Description)
                    .FirstOrDefault()
            })
            .ToListAsync();
    }

}
