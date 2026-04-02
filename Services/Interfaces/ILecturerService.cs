using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface ILecturerService
    {
        Task<List<LecturerDto>> GetAllAsync();
        Task<LecturerDto?> GetByIdAsync(Guid lecturerId);
        Task CreateAsync(CreateLecturerDto dto);
        Task UpdateAsync(Guid lecturerId, CreateLecturerDto dto);
        Task DeleteAsync(Guid lecturerId);
    }
}
