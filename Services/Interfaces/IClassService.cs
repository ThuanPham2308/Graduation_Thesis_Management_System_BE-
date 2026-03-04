using Graduation_Thesis_Management_System_BE.Models.Dtos.ClassDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllAsync();
        Task<ClassDto?> GetByIdAsync(string classId);
        Task CreateAsync(CreateClassDto dto);
        Task UpdateAsync(string classId, CreateClassDto dto);
        Task DeleteAsync(string classId);
    }
}
