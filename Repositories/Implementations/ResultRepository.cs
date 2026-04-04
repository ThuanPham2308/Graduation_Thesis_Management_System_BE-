using Graduation_Thesis_Management_System_BE.Data.Entities;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class ResultRepository : IResultRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public ResultRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Result>> GetAllAsync()
        {
            return await _context.Results
                .Include(r => r.Topic)
                .ToListAsync();
        }

        public async Task<Result?> GetByTopicIdAsync(Guid topicId)
        {
            return await _context.Results
                .Include(r => r.Topic)
                .FirstOrDefaultAsync(r => r.TopicId == topicId);
        }

        public async Task AddAsync(Result result)
        {
            await _context.Results.AddAsync(result);
        }

        public Task UpdateAsync(Result result)
        {
            _context.Results.Update(result);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
