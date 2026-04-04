using Graduation_Thesis_Management_System_BE.Models.Dtos.TopicDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface ITopicService
    {
        Task<List<TopicDto>> GetAllAsync();
        Task<TopicDto?> GetByIdAsync(Guid topicId);
        Task CreateAsync(CreateTopicDto dto);
        Task UpdateAsync(Guid topicId, CreateTopicDto dto);
        Task DeleteAsync(Guid topicId);
    }
}
