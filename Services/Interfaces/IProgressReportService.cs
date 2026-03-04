using Graduation_Thesis_Management_System_BE.Models.Dtos.ProgressReportDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IProgressReportService
    {
        Task<List<ProgressReportDto>> GetByTopicAsync(string topicId);
        Task CreateAsync(CreateProgressReportDto dto);
        Task UpdateAsync(string reportId, UpdateProgressReportDto dto);
    }
}
