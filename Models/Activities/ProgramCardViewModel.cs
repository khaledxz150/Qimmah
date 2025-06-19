namespace Qimmah.Models.Activities
{
    public class ProgramCardViewModel
    {
        public string ImageUrl { get; set; } = "https://picsum.photos/200/300";
        public string Type { get; set; } // "برنامج"
        public string Title { get; set; }
        public string Description { get; set; }
        public string PriceLabel { get; set; } // "مجاني"
        public string Duration { get; set; } // "8h 12m"
        public string ParticipantCount { get; set; } // "30 أعضاء"
    }
}
