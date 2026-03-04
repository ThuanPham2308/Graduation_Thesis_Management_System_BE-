namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos
{
    public class CreateThesisDto
    {
        public string ThesisId { get; set; } 
        public string TopicId { get; set; } 
        public string? FilePath { get; set; }
        public string? Description { get; set; }
    }
}
