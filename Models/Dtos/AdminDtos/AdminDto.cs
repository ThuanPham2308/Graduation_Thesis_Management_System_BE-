namespace Graduation_Thesis_Management_System_BE.Models.Dtos.AdminDtos
{
    public class AdminDto
    {
        public Guid AdminId { get; set; } 
        public Guid? UserId { get; set; } 
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
