using Qimmah.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Qimmah.Data.Activities
{
    [Table("Programs_Description_Localization", Schema = "Activities")]
    [PrimaryKey(nameof(ProgramID), nameof(LanguageID))]

    public class ProgramDescriptionLocalization : BaseLocalization
    {
        public long ProgramID { get; set; }
        [ForeignKey(nameof(ProgramID))]
        public Programs Program { get; set; }

     

    }
}
