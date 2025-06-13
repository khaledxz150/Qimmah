using Qimmah.Data.System;
using Qimmah.Enums.System;
using Qimmah.Models.Common;

namespace Qimmah.Core.System;

public interface ILookupService
{
    public Task<Lookup> GetLookupByIdAsync(int id);
    public Task<Lookup> GetLookupByCategoryAndIdAsync(int categoryId, int id);
    public Task<List<Lookup>> GetLookupsByCategoryAsync(int categoryId);
    public Task<List<DDLViewModel>> GetLookupsAsDDLAsync(LookupCategoryEnum categoryEnum, int LanguageId = 2);
}
