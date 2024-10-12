using Job_portal_backend_net8.Core.Enums;

namespace Job_portal_backend_net8.Core.DTOs.Company
{
    public class CompanyCreateDTO
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
