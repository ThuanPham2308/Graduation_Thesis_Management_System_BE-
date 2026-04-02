namespace Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerDtos
{
    public class LecturerDto
    {
        public Guid LecturerId { get; set; }
        public string Position { get; set; }
        public string Specialization { get; set; }
        public string AcademicDegree { get; set; }

        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
