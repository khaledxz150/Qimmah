using Microsoft.EntityFrameworkCore;

using Qimmah.Data.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimmah.Data.Activities
{
    [Table("Programs_Title_Localization", Schema = "Activities")]
    [PrimaryKey(nameof(ProgramID), nameof(LanguageID))]

    public class ProgramTitleLocalization : BaseLocalization
    {
        public long ProgramID { get; set; }
        [ForeignKey(nameof(ProgramID))]
        public Programs Program { get; set; }
        [MaxLength(500)]
        public string ShortDescription { get; set; }

    }
}
