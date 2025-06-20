using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Qimmah.Data.Activities
{
    [Table("ProgramComponents", Schema = "Activities")]
    public class ProgramComponent
    {
        [Key]
        public long Id { get; set; }
        public long ProgramId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public Programs Program { get; set; }

        public ICollection<ProgramComponentLocalization> ProgramComponentLocalizations { get; set; }
    }
}
