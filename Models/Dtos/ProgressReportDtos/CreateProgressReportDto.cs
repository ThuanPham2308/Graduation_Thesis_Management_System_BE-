namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ProgressReportDtos
{
    public class CreateProgressReportDto
    {
        public string ReportId { get; set; }
        public string TopicId { get; set; } 
        public string? ReportContent { get; set; }
        public string? FilePath { get; set; }
    }
}
