namespace Graduation_Thesis_Management_System_BE.Models.Dtos.DefenseSessionDtos
{
    public class CreateDefenseSessionDto
    {
        public string SessionId { get; set; }
        public string SessionName { get; set; }
        public string AcademicYear { get; set; }
        public string? Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Note { get; set; }
    }
}
