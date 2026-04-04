using Graduation_Thesis_Management_System_BE.Models.Dtos.ProgressReportDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IProgressReportService
    {
        Task<List<ProgressReportDto>> GetByTopicAsync(Guid topicId);
        Task CreateAsync(CreateProgressReportDto dto);
        Task UpdateAsync(Guid reportId, UpdateProgressReportDto dto);
    }
}
