using Graduation_Thesis_Management_System_BE.Models.Dtos.TopicDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _repo;

        public TopicService(ITopicRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TopicDto>> GetAllAsync()
        {
            var topics = await _repo.GetAllAsync();

            return topics.Select(t => new TopicDto
            {
                TopicId = t.TopicId,
                TopicTitle = t.TopicTitle,
                Description = t.Description,
                StudentId = t.StudentId,
                SessionId = t.SessionId,
                RegistrationDate = t.RegistrationDate,
                ApprovalStatus = t.ApprovalStatus
            }).ToList();
        }

        public async Task<TopicDto?> GetByIdAsync(string topicId)
        {
            var topic = await _repo.GetByIdAsync(topicId);
            if (topic == null) return null;

            return new TopicDto
            {
                TopicId = topic.TopicId,
                TopicTitle = topic.TopicTitle,
                Description = topic.Description,
                StudentId = topic.StudentId,
                SessionId = topic.SessionId,
                RegistrationDate = topic.RegistrationDate,
                ApprovalStatus = topic.ApprovalStatus
            };
        }

        public async Task CreateAsync(CreateTopicDto dto)
        {
            var topic = new Topic
            {
                TopicId = Guid.NewGuid().ToString("N").Substring(0, 20),
                TopicTitle = dto.TopicTitle,
                Description = dto.Description,
                StudentId = dto.StudentId,
                SessionId = dto.SessionId,
                RegistrationDate = DateTime.Now,
                ApprovalStatus = "Chờ duyệt"
            };

            await _repo.AddAsync(topic);
        }

        public async Task UpdateAsync(string topicId, CreateTopicDto dto)
        {
            var topic = await _repo.GetByIdAsync(topicId);
            if (topic == null) throw new Exception("Topic not found");

            topic.TopicTitle = dto.TopicTitle;
            topic.Description = dto.Description;
            topic.SessionId = dto.SessionId;

            await _repo.UpdateAsync(topic);
        }

        public async Task DeleteAsync(string topicId)
        {
            var topic = await _repo.GetByIdAsync(topicId);
            if (topic == null) throw new Exception("Topic not found");

            await _repo.DeleteAsync(topic);
        }
    }
}
