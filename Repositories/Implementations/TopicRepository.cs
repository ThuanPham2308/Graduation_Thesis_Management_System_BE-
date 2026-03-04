using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class TopicRepository : ITopicRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public TopicRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic?> GetByIdAsync(string topicId)
        {
            return await _context.Topics
                .FirstOrDefaultAsync(t => t.TopicId == topicId);
        }

        public async Task AddAsync(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Topic topic)
        {
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Topic topic)
        {
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }
    }
}
