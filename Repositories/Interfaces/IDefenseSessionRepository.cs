using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IDefenseSessionRepository
    {
        Task<List<DefenseSession>> GetAllAsync();
        Task<DefenseSession?> GetByIdAsync(Guid sessionId);
        Task AddAsync(DefenseSession session);
        Task UpdateAsync(DefenseSession session);
        Task DeleteAsync(DefenseSession session);
    }
}
