using Job_portal_backend_net8.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_portal_backend_net8.Core.Entities
{
    public class Job: BaseEntity
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        //relations

        //relationship with Company model
        [ForeignKey(nameof(CompanyId))]
        public long CompanyId { get; set; } 
        public Company Company { get; set; }

        //relationship with Candidate model
        public IList<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
