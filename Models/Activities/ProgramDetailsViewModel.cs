using Qimmah.Data.Activities;
using Qimmah.Data.Base;

namespace Qimmah.Models.Activities
{
    public class ProgramDetailsViewModel 
    {
        public long ID { get; set; }
        public ProgramTitleDescriptionDTO TitleAndShortDescription { get; set; }
        public string Title { get { return TitleAndShortDescription.Title; } }
        public string ShortDescription { get { return TitleAndShortDescription.ShortDescription; } }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFree { get; set; }
        public decimal? Price { get; set; }
        public int? DiscountPercent { get; set; }
        public int DurationMinutes { get; set; }
        public int ParticipantCount { get; set; }
        public double? Rating { get; set; }
        public int? RatingCount { get; set; }
        public string CategoryName { get; set; }
        public DateTime StartDate { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public List<string> Goals { get; set; }
        public List<string> Components { get; set; }
        public string OrganizerName { get; set; }
        public string? OrganizerImage { get; set; }
        public List<Sessions> SessionsOriginal { get;  set; }

        public List<string> Sessions { get; set; } = new List<string>();
    }

    public class ProgramTitleDescriptionDTO
    {
        public ProgramTitleDescriptionDTO(string description, string shortDescription)
        {
            Title = description;
            ShortDescription = shortDescription;
        }

        public string Title { get; set; }
        public string ShortDescription { get; set; }

    }

}
