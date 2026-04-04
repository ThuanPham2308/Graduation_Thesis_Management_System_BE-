using Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IThesisService
    {
        Task<ThesisDto?> GetByTopicAsync(Guid topicId);
        Task CreateAsync(CreateThesisDto dto);
        Task UpdateAsync(Guid thesisId, UpdateThesisDto dto);
        Task ApproveAsync(Guid thesisId, ApproveThesisDto dto);
    }
}
