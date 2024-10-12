using System.ComponentModel.DataAnnotations.Schema;

namespace Job_portal_backend_net8.Core.Entities
{
    public class Candidate: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }

        //relations

        [ForeignKey(nameof(JobId))]
        public long JobId { get; set; }
        public Job Job { get; set; }
    }
}
