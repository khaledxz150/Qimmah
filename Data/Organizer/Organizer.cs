using System.ComponentModel.DataAnnotations.Schema;

using Qimmah.Data.Base;

namespace Qimmah.Data.Organizer
{

    [Table("Organizers")]
    public class Organizer : EntityBase<long>
    {
        public string? ImageUrl { get; set; } // Organizer's photo or logo

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }

        // Navigation
        public ICollection<OrganizerLocalization> OrganizerLocalizations { get; set; }
    }
}
