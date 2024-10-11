using System.ComponentModel.DataAnnotations;

namespace Job_portal_backend_net8.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }=true;
    }
}
