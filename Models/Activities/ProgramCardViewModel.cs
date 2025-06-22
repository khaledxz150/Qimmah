
namespace Qimmah.Models.Activities
{
    public class ProgramCardViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string liveBrodcastLink { get; set; }
        public bool IsCurrentlyBroadCasting { get; set; }

        public bool IsFree { get; set; }
        public decimal? PriceValue { get; set; } // Store the actual price
        public string Price => IsFree ? FreeText : PriceValue?.ToString();
        public string FreeText { get; set; } // Set this after query execution
        public int? DiscountPercent { get; set; }
        public int DurationMinutes { get; set; }
        public int ParticipantCount { get; set; }
        public double? Rating { get; set; }
        public int? RatingCount { get; set; }
        public string CategoryName { get; set; }

        public string SessionDateTimeFormatted { get; set; }
        public DateTime SessionStartDateTime { get; internal set; }
        public DateTime SessionEndDateTime { get; internal set; }
    }
}
