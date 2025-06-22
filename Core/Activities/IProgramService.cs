using Qimmah.Data.Activities;
using Qimmah.Models.Activities;
using Qimmah.Models.Common.Filters;

namespace Qimmah.Core.Activities
{
    public interface IProgramService
    {
        Task<List<ProgramCategoryViewModel>> GetCategoriesAsync();
        Task<PaginatedList<ProgramCardViewModel>> GetProgramCardsAsync(int page,
        int pageSize,
        string search = "",
        string orderBy = "1",
        string categories = "");
        Task<ProgramDetailsViewModel> GetProgramDetailsAsync(long programId);
        Task<List<ProgramCardViewModel>> GetUserCurrentBroadCasts();
    }
}
