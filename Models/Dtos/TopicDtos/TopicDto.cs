namespace Graduation_Thesis_Management_System_BE.Models.Dtos.TopicDtos
{
    public class TopicDto
    {
        public string TopicId { get; set; } = null!;
        public string TopicTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public string? SessionId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string ApprovalStatus { get; set; } = null!;
    }
}
