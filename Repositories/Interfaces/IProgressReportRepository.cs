using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IProgressReportRepository
    {
        Task<List<ProgressReport>> GetByTopicAsync(string topicId);
        Task<ProgressReport?> GetByIdAsync(string reportId);
        Task AddAsync(ProgressReport report);
        Task UpdateAsync(ProgressReport report);
    }
}
