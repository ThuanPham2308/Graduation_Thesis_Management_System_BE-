namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos
{
    public class ThesisDto
    {
        public string ThesisId { get; set; } 
        public string TopicId { get; set; } 
        public DateTime? SubmissionDate { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }
        public string ApprovalStatus { get; set; } 
        public string DefenseConfirmation { get; set; } 
        public string DefenseStatus { get; set; } 
        public DateTime? ApprovalDate { get; set; }
    }
}
