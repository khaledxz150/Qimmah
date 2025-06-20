using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Qimmah.Data.Base;

namespace Qimmah.Data.Activities
{
    [Table(" ProgramCategory_Localization", Schema = "Activities")]
    [PrimaryKey(nameof(ProgramCategoryID),nameof(LanguageID))]
    public class ProgramCategoryLocalization : BaseLocalization
    {
        public int ProgramCategoryID { get; set; }
        [ForeignKey(nameof(ProgramCategoryID))]
        public ProgramCategory ProgramCategory { get; set; }

      
    }
}
