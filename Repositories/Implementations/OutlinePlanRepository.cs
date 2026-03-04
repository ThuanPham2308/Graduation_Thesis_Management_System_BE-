using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class OutlinePlanRepository : IOutlinePlanRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public OutlinePlanRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<OutlinePlan?> GetByTopicAsync(string topicId)
        {
            return await _context.OutlinePlans
                .FirstOrDefaultAsync(x => x.TopicId == topicId);
        }

        public async Task<OutlinePlan?> GetByIdAsync(string outlineId)
        {
            return await _context.OutlinePlans.FindAsync(outlineId);
        }

        public async Task AddAsync(OutlinePlan outlinePlan)
        {
            _context.OutlinePlans.Add(outlinePlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OutlinePlan outlinePlan)
        {
            _context.OutlinePlans.Update(outlinePlan);
            await _context.SaveChangesAsync();
        }
    }
}
