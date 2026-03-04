using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class ThesisRepository : IThesisRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public ThesisRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Thesis?> GetByTopicAsync(string topicId)
        {
            return await _context.Theses
                .FirstOrDefaultAsync(x => x.TopicId == topicId);
        }

        public async Task<Thesis?> GetByIdAsync(string thesisId)
        {
            return await _context.Theses.FindAsync(thesisId);
        }

        public async Task AddAsync(Thesis thesis)
        {
            _context.Theses.Add(thesis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Thesis thesis)
        {
            _context.Theses.Update(thesis);
            await _context.SaveChangesAsync();
        }
    }
}
