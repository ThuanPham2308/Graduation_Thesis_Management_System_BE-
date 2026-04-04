namespace Graduation_Thesis_Management_System_BE.Models.Dtos.StudentDtos
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public int StudyYear { get; set; }

        public Guid? UserId { get; set; }
        public string FullName { get; set; }

        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
