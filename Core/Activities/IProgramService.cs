using Qimmah.Models.Activities;
using Qimmah.Models.Common.Filters;

namespace Qimmah.Core.Activities
{
    public interface IProgramService
    {
        Task<PaginatedList<ProgramCardViewModel>> GetProgramCardsAsync( int page, int pageSize);
        Task<ProgramDetailsViewModel> GetProgramDetailsAsync(long programId);
        Task<List<ProgramCardViewModel>> GetUserCurrentBroadCasts();
    }
}
