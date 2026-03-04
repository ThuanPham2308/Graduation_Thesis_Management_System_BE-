using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class LecturerAssignmentRepository : ILecturerAssignmentRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public LecturerAssignmentRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<LecturerAssignment>> GetByTopicAsync(string topicId)
        {
            return await _context.LecturerAssignments
                .Where(x => x.TopicId == topicId)
                .ToListAsync();
        }

        public async Task AddAsync(LecturerAssignment assignment)
        {
            _context.LecturerAssignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string topicId, string lecturerId, string role)
        {
            var entity = await _context.LecturerAssignments.FindAsync(topicId, lecturerId, role);
            if (entity != null)
            {
                _context.LecturerAssignments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
