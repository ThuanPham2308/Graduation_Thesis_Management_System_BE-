namespace Graduation_Thesis_Management_System_BE.Models.Dtos.UserDTos
{
    public class UpdateUserDto
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Hometown { get; set; }
        public string? Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
