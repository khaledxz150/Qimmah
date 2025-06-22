using Qimmah.Core.Activities;
using Qimmah.Data.Activities;
using Qimmah.Data;
using static Qimmah.DTOs.Activities.ProgramRatingDto;
using Microsoft.EntityFrameworkCore;
using Qimmah.DTOs.Activities;

namespace Qimmah.Application.Activities
{
    public class ProgramRatingService : IProgramRatingService
    {
        private readonly ApplicationDbContext _context;

        public ProgramRatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RateProgramAsync(long programId, long userId, int rating, string reviewText = null)
        {
            // Validate rating
            if (rating < 1 || rating > 5)
                return false;

            // Check if user already rated this program
            var existingRating = await _context.ProgramRatings
                .FirstOrDefaultAsync(r => r.ProgramId == programId && r.UserId == userId);

            if (existingRating != null)
            {
                // Update existing rating
                return await UpdateRatingAsync(programId, userId, rating, reviewText);
            }

            // Create new rating
            var programRating = new ProgramRating
            {
                ProgramId = programId,
                UserId = userId,
                Rating = rating,
                ReviewText = reviewText,
                RatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.ProgramRatings.Add(programRating);
            await _context.SaveChangesAsync();

            // Recalculate program rating
            await RecalculateProgramRatingAsync(programId);

            return true;
        }

        public async Task<bool> UpdateRatingAsync(long programId, long userId, int rating, string reviewText = null)
        {
            if (rating < 1 || rating > 5)
                return false;

            var existingRating = await _context.ProgramRatings
                .FirstOrDefaultAsync(r => r.ProgramId == programId && r.UserId == userId && r.IsActive);

            if (existingRating == null)
                return false;

            existingRating.Rating = rating;
            existingRating.ReviewText = reviewText;
            existingRating.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await RecalculateProgramRatingAsync(programId);

            return true;
        }

        public async Task<bool> DeleteRatingAsync(long programId, long userId)
        {
            var rating = await _context.ProgramRatings
                .FirstOrDefaultAsync(r => r.ProgramId == programId && r.UserId == userId && r.IsActive);

            if (rating == null)
                return false;

            rating.IsActive = false;
            rating.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await RecalculateProgramRatingAsync(programId);

            return true;
        }

        public async Task<ProgramRatingStatsDto> GetProgramRatingStatsAsync(long programId)
        {
            var ratings = await _context.ProgramRatings
                .Where(r => r.ProgramId == programId && r.IsActive)
                .Select(r => r.Rating)
                .ToListAsync();

            if (!ratings.Any())
            {
                return new ProgramRatingStatsDto
                {
                    AverageRating = 0,
                    TotalRatings = 0,
                    RatingDistribution = new Dictionary<int, int>()
                };
            }

            var distribution = ratings
                .GroupBy(r => r)
                .ToDictionary(g => g.Key, g => g.Count());

            // Fill missing ratings with 0
            for (int i = 1; i <= 5; i++)
            {
                if (!distribution.ContainsKey(i))
                    distribution[i] = 0;
            }

            return new ProgramRatingStatsDto
            {
                AverageRating = Math.Round(ratings.Average(), 1),
                TotalRatings = ratings.Count,
                RatingDistribution = distribution.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            };
        }

        public async Task<List<ProgramRatingDto>> GetProgramRatingsAsync(long programId, int page = 1, int pageSize = 10)
        {
            return await _context.ProgramRatings
                .Where(r => r.ProgramId == programId && r.IsActive)
                .OrderByDescending(r => r.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new ProgramRatingDto
                {
                    Id = r.ID,
                    UserId = r.UserId,
                    UserName = r.User.Email,
                    //UserAvatar = r.User.ProfileImageUrl,
                    Rating = r.Rating,
                    ReviewText = r.ReviewText,
                    RatedAt = r.RatedAt,
                    IsVerifiedPurchase = r.IsVerifiedPurchase,
                    HelpfulCount = r.HelpfulCount
                })
                .ToListAsync();
        }

        public async Task<ProgramRatingDto> GetUserRatingAsync(long programId, long userId)
        {
            return await _context.ProgramRatings
                .Where(r => r.ProgramId == programId && r.UserId == userId && r.IsActive)
                .Select(r => new ProgramRatingDto
                {
                    Id = r.ID,
                    UserId = r.UserId,
                    Rating = r.Rating,
                    ReviewText = r.ReviewText,
                    RatedAt = r.RatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task RecalculateProgramRatingAsync(long programId)
        {
            var program = await _context.Programs.FindAsync(programId);
            if (program == null) return;

            var ratings = await _context.ProgramRatings
                .Where(r => r.ProgramId == programId && r.IsActive)
                .Select(r => r.Rating)
                .ToListAsync();

            if (ratings.Any())
            {
                program.Rating = Math.Round(ratings.Average(), 1);
                program.RatingCount = ratings.Count;
            }
            else
            {
                program.Rating = null;
                program.RatingCount = null;
            }

            await _context.SaveChangesAsync();
        }
    }
}
