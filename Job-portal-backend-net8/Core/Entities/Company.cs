using Job_portal_backend_net8.Core.Enums;

namespace Job_portal_backend_net8.Core.Entities
{
    public class Company: BaseEntity
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }

        public IList<Job> Jobs { get; set; }

    }
}
