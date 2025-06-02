using System.ComponentModel.DataAnnotations;

namespace Qimmah.Data.Base
{
    public class EntityBase : EntityProperities
    {
        [Key]
        public long ID{ get; set; } 

    }
    public class EntityBase<T> : EntityProperities
    {
        [Key]
        public T ID { get; set; }

    }
}
