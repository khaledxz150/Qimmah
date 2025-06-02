using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qimmah.Data.Base
{
    public class EntityProperities
    {

        [Column(TypeName = "bit")]
        [Required]
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "bit")]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
