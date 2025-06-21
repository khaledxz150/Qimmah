using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Qimmah.Data.Activities
{
    [Table("ProgramGoals", Schema = "Activities")]
    public class ProgramGoal
    {
        [Key]
        public long Id { get; set; }
        public long ProgramId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public Programs Program { get; set; }

        public ICollection<ProgramGoalLocalization> ProgramGoalLocalizations { get; set; }
    }
}
