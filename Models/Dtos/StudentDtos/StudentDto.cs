namespace Graduation_Thesis_Management_System_BE.Models.Dtos.StudentDtos
{
    public class StudentDto
    {
        public string StudentId { get; set; }
        public int StudyYear { get; set; }

        public string UserId { get; set; }
        public string FullName { get; set; }

        public string ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
