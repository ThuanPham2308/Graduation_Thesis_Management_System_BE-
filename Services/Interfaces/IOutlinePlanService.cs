using Graduation_Thesis_Management_System_BE.Models.Dtos.OutlinePlanDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IOutlinePlanService
    {
        Task<OutlinePlanDto?> GetByTopicAsync(string topicId);
        Task CreateAsync(CreateOutlinePlanDto dto);
        Task UpdateAsync(string outlineId, UpdateOutlinePlanDto dto);
    }
}
