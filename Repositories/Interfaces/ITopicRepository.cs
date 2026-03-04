using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetAllAsync();
        Task<Topic?> GetByIdAsync(string topicId);
        Task AddAsync(Topic topic);
        Task UpdateAsync(Topic topic);
        Task DeleteAsync(Topic topic);
    }
}
