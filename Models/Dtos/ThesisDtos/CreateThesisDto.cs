namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos
{
    public class CreateThesisDto
    {
        public Guid ThesisId { get; set; } 
        public Guid TopicId { get; set; } 
        public string? FilePath { get; set; }
        public string? Description { get; set; }
    }
}
