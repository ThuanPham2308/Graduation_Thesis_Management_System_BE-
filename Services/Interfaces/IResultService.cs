using Graduation_Thesis_Management_System_BE.Models.Dtos.ResultDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IResultService
    {
        Task<List<ResultDto>> GetAllAsync();
        Task<ResultDto?> GetByTopicIdAsync(Guid topicId);
        Task CreateAsync(CreateResultDto dto);
        Task UpdateAsync(Guid topicId, UpdateResultDto dto);
    }
}
