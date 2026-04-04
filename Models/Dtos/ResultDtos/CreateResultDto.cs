namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ResultDtos
{
    public class CreateResultDto
    {
        public Guid ResultId { get; set; }
        public Guid TopicId { get; set; } 
        public decimal? ProcessScore { get; set; }
        public decimal? DefenseScore { get; set; }
        public string? Comment { get; set; }
    }
}
