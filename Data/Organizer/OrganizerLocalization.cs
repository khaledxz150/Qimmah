using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Qimmah.Data.Base;

namespace Qimmah.Data.Organizer
{
    [Table("Organizers_Localization")]
    public class OrganizerLocalization : BaseLocalization
    {
        public long OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Organizer Organizer { get; set; }
    }
}
