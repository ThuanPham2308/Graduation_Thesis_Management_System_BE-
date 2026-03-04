namespace Graduation_Thesis_Management_System_BE.Models.Dtos.OutlinePlanDtos
{
    public class OutlinePlanDto
    {
        public string OutlineId { get; set; } 
        public string TopicId { get; set; } 
        public string OutlineContent { get; set; } 
        public string ExecutionPlan { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? Note { get; set; }
    }
}
