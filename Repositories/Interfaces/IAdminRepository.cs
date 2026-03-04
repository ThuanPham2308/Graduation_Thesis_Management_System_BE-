using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAsync();
        Task<Admin?> GetByIdAsync(string adminId);
        Task AddAsync(Admin admin);
        Task DeleteAsync(Admin admin);
        Task SaveAsync();
    }
}
