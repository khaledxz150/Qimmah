using System.ComponentModel.DataAnnotations;

namespace Qimmah.DTOs.Activities
{
 
        public class ProgramRatingDto
        {
            public long Id { get; set; }
            public long UserId { get; set; }
            public string UserName { get; set; }
            public string UserAvatar { get; set; }
            public int Rating { get; set; }
            public string ReviewText { get; set; }
            public DateTime RatedAt { get; set; }
            public bool IsVerifiedPurchase { get; set; }
            public int HelpfulCount { get; set; }
        }

        public class ProgramRatingStatsDto
        {
            public double AverageRating { get; set; }
            public int TotalRatings { get; set; }
            public Dictionary<int, int> RatingDistribution { get; set; }
        }

        public class RateProgramRequest
        {
            [Range(1, 5)]
            public int Rating { get; set; }

            [MaxLength(1000)]
            public string ReviewText { get; set; }
        }
    
}
