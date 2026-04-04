namespace Graduation_Thesis_Management_System_BE.Models.Dtos.TopicDtos
{
    public class CreateTopicDto
    {
        public string TopicTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid StudentId { get; set; } 
        public Guid? SessionId { get; set; }
    }
}
