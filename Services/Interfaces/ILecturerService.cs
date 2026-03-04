using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface ILecturerService
    {
        Task<List<LecturerDto>> GetAllAsync();
        Task<LecturerDto?> GetByIdAsync(string lecturerId);
        Task CreateAsync(CreateLecturerDto dto);
        Task UpdateAsync(string lecturerId, CreateLecturerDto dto);
        Task DeleteAsync(string lecturerId);
    }
}
