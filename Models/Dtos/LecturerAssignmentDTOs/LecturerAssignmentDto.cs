namespace Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerAssignmentDTOs
{
    public class LecturerAssignmentDto
    {
        public Guid TopicId { get; set; }
        public Guid LecturerId { get; set; } 
        public string Role { get; set; } 
    }
}
