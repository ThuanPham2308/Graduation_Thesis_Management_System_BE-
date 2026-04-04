using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<List<Result>> GetAllAsync();
        Task<Result?> GetByTopicIdAsync(Guid topicId);
        Task AddAsync(Result result);
        Task UpdateAsync(Result result);
        Task SaveAsync();
    }
}
