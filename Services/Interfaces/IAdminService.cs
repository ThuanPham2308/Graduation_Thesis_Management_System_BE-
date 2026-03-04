using Graduation_Thesis_Management_System_BE.Models.Dtos.AdminDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<AdminDto>> GetAllAsync();
        Task CreateAsync(AdminCreateDto dto);
        Task DeleteAsync(string adminId);
    }
}
