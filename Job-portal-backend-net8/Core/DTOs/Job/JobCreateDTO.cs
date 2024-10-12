using Job_portal_backend_net8.Core.Enums;

namespace Job_portal_backend_net8.Core.DTOs.Job
{
    public class JobCreateDTO
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long CompanyId { get; set; }
    }
}
