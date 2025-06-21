using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Qimmah.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Qimmah.Data.Activities
{
    [Table("ProgramComponents_Localization", Schema = "Activities")]
    [PrimaryKey(nameof(ProgramComponentID), nameof(LanguageID))]

    public class ProgramComponentLocalization : BaseLocalization
    {
        public long ProgramComponentID { get; set; }
        [ForeignKey(nameof(ProgramComponentID))]
        public ProgramComponent ProgramComponent { get; set; }

        [Required, MaxLength(300)]
        public string ComponentText { get; set; }
    }
}
