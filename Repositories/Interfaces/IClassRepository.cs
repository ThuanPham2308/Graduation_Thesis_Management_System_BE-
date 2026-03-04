using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllAsync();
        Task<Class?> GetByIdAsync(string classId);
        Task AddAsync(Class classEntity);
        Task UpdateAsync(Class classEntity);
        Task DeleteAsync(Class classEntity);
    }
}
