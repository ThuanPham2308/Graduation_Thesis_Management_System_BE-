namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ResultDtos
{
    public class CreateResultDto
    {
        public string ResultId { get; set; }
        public string TopicId { get; set; } 
        public decimal? ProcessScore { get; set; }
        public decimal? DefenseScore { get; set; }
        public string? Comment { get; set; }
    }
}
