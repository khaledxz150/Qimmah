using Qimmah.DTOs.Activities;

using static Qimmah.DTOs.Activities.ProgramRatingDto;

namespace Qimmah.Core.Activities
{
    public interface IProgramRatingService
    {
        Task<bool> RateProgramAsync(long programId, long userId, int rating, string reviewText = null);
        Task<bool> UpdateRatingAsync(long programId, long userId, int rating, string reviewText = null);
        Task<bool> DeleteRatingAsync(long programId, long userId);
        Task<ProgramRatingStatsDto> GetProgramRatingStatsAsync(long programId);
        Task<List<ProgramRatingDto>> GetProgramRatingsAsync(long programId, int page = 1, int pageSize = 10);
        Task<ProgramRatingDto> GetUserRatingAsync(long programId, long userId);
        Task RecalculateProgramRatingAsync(long programId);
    }
}
