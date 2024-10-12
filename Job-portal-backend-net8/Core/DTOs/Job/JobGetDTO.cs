using Job_portal_backend_net8.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_portal_backend_net8.Core.DTOs.Job
{
    public class JobGetDTO
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
