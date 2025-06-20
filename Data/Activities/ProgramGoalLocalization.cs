using Qimmah.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Qimmah.Data.Activities
{
    [Table("ProgramGoals_Localization", Schema = "Activities")]
    [PrimaryKey(nameof(ProgramGoalID), nameof(LanguageID))]

    public class ProgramGoalLocalization : BaseLocalization
    {
        public long ProgramGoalID { get; set; }
        [ForeignKey(nameof(ProgramGoalID))]
        public ProgramGoal ProgramGoal { get; set; }

        [Required, MaxLength(300)]
        public string GoalText { get; set; }
    }
}
