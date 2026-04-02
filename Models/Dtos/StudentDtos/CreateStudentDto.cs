namespace Graduation_Thesis_Management_System_BE.Models.Dtos.StudentDtos
{
    public class CreateStudentDto
    {
        public Guid StudentId { get; set; }
        public int StudyYear { get; set; }
        public Guid UserId { get; set; }
        public string ClassId { get; set; }
    }
}
