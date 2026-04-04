using Graduation_Thesis_Management_System_BE.Models.Dtos.OutlinePlanDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IOutlinePlanService
    {
        Task<OutlinePlanDto?> GetByTopicAsync(Guid topicId);
        Task CreateAsync(CreateOutlinePlanDto dto);
        Task UpdateAsync(Guid outlineId, UpdateOutlinePlanDto dto);
    }
}
