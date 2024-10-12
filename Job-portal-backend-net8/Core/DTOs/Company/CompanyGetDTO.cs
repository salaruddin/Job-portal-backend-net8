using Job_portal_backend_net8.Core.Enums;

namespace Job_portal_backend_net8.Core.DTOs.Company
{
    public class CompanyGetDTO
    {
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
