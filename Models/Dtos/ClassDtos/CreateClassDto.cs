namespace Graduation_Thesis_Management_System_BE.Models.Dtos.ClassDtos
{
    public class CreateClassDto
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string Cohort { get; set; }
        public string AcademicYear { get; set; }
        public string? Note { get; set; }
        public string LecturerId { get; set; }
    }
}
