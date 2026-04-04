using Graduation_Thesis_Management_System_BE.Data.Entities;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class ProgressReportRepository : IProgressReportRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public ProgressReportRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProgressReport>> GetByTopicAsync(Guid topicId)
        {
            return await _context.ProgressReports
                .Where(x => x.TopicId == topicId)
                .OrderByDescending(x => x.UpdatedDate)
                .ToListAsync();
        }

        public async Task<ProgressReport?> GetByIdAsync(Guid reportId)
        {
            return await _context.ProgressReports.FindAsync(reportId);
        }

        public async Task AddAsync(ProgressReport report)
        {
            _context.ProgressReports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProgressReport report)
        {
            _context.ProgressReports.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}
