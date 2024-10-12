using System.ComponentModel.DataAnnotations.Schema;

namespace Job_portal_backend_net8.Core.DTOs.Candidate
{
    public class CandidateGetDTO
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long JobId { get; set; }
        public string JobTitle { get; set; }
    }
}
