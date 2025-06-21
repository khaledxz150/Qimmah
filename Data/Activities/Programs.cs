using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Qimmah.Data.System;
using Qimmah.Data.Base;
using Qimmah.Data.User;

namespace Qimmah.Data.Activities
{
   [Table("Programs", Schema ="Activities")]
    public class Programs : EntityBase<long>
    {

        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationMinutes { get; set; }
        public int ParticipantCount { get; set; }
        public bool IsFree { get; set; }
        public decimal? Price { get; set; }
        public int? DiscountPercent { get; set; }
        public double? Rating { get; set; }
        public int? RatingCount { get; set; }

        public int ProgramCategoryId { get; set; }
        [ForeignKey(nameof(ProgramCategoryId))]
        public ProgramCategory ProgramCategory { get; set; }


        public long OrganizerId { get; set; }
        [ForeignKey(nameof(OrganizerId))]
        public Qimmah.Data.Organizer.Organizer Organizer { get; set; }

        public int CountryLookupID { get; set; }
        [ForeignKey(nameof(CountryLookupID))]
        public Lookup CountryLookup { get; set; }

        public int CityLookupID { get; set; }
        [ForeignKey(nameof(CityLookupID))]
        public Lookup CityLookup { get; set; }


        // Navigation
        public ICollection<ProgramTitleLocalization> ProgramTitleLocalization { get; set; }
        public ICollection<ProgramDescriptionLocalization> ProgramDescriptionLocalization { get; set; }
        public ICollection<ProgramGoal> ProgramGoals { get; set; }
        public ICollection<ProgramComponent> ProgramComponents { get; set; }
        public ICollection<Sessions> Sessions { get; set; } // Added Sessions navigation
        public bool IsCurrentlyBroadCasting { get;  set; }
        public ICollection<Users> Users { get; set; }
    }
}
