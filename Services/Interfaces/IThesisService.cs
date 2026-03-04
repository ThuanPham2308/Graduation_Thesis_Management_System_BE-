using Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IThesisService
    {
        Task<ThesisDto?> GetByTopicAsync(string topicId);
        Task CreateAsync(CreateThesisDto dto);
        Task UpdateAsync(string thesisId, UpdateThesisDto dto);
        Task ApproveAsync(string thesisId, ApproveThesisDto dto);
    }
}
