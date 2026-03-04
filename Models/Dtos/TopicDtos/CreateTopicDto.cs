namespace Graduation_Thesis_Management_System_BE.Models.Dtos.TopicDtos
{
    public class CreateTopicDto
    {
        public string TopicTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public string? SessionId { get; set; }
    }
}
