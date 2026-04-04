using Graduation_Thesis_Management_System_BE.Models.Dtos.ClassDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllAsync();
        Task<ClassDto?> GetByIdAsync(Guid classId);
        Task CreateAsync(CreateClassDto dto);
        Task UpdateAsync(Guid classId, CreateClassDto dto);
        Task DeleteAsync(Guid classId);
    }
}
