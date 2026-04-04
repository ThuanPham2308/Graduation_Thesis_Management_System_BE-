namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ProgressReportDtos
{
    public class ProgressReportDto
    {
        public Guid ReportId { get; set; } 
        public Guid TopicId { get; set; } 
        public string? ReportContent { get; set; }
        public string? FilePath { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Comment { get; set; }
    }
}
