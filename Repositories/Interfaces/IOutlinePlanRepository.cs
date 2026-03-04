using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IOutlinePlanRepository
    {
        Task<OutlinePlan?> GetByTopicAsync(string topicId);
        Task<OutlinePlan?> GetByIdAsync(string outlineId);
        Task AddAsync(OutlinePlan outlinePlan);
        Task UpdateAsync(OutlinePlan outlinePlan);
    }
}
