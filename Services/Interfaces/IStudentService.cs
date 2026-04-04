using Graduation_Thesis_Management_System_BE.Models.Dtos.StudentDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(Guid studentId);
        Task CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(Guid studentId, CreateStudentDto dto);
        Task DeleteAsync(Guid studentId);
    }
}
