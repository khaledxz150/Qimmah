using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimmah.Data.Activities
{
    [Table(" ProgramCategory", Schema = "Activities")]

    public class ProgramCategory
    {
        [Key]
        public int ID { get; set; }

        public bool IsActive { get; set; } = true;
        public int OrderID { get; set; }

        // Navigation
        public ICollection<ProgramCategoryLocalization> ProgramCategoryLocalizations { get; set; }
        public ICollection<Programs> Programs { get; set; }
    }
}
