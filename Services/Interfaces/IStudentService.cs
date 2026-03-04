using Graduation_Thesis_Management_System_BE.Models.Dtos.StudentDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(string studentId);
        Task CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(string studentId, CreateStudentDto dto);
        Task DeleteAsync(string studentId);
    }
}
