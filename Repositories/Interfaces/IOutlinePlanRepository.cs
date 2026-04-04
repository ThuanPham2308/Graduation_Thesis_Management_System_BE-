using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IOutlinePlanRepository
    {
        Task<OutlinePlan?> GetByTopicAsync(Guid topicId);
        Task<OutlinePlan?> GetByIdAsync(Guid outlineId);
        Task AddAsync(OutlinePlan outlinePlan);
        Task UpdateAsync(OutlinePlan outlinePlan);
    }
}
