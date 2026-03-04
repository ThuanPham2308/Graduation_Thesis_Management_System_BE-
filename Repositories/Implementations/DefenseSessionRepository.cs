using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class DefenseSessionRepository : IDefenseSessionRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public DefenseSessionRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<DefenseSession>> GetAllAsync()
            => await _context.DefenseSessions.ToListAsync();

        public async Task<DefenseSession?> GetByIdAsync(string sessionId)
            => await _context.DefenseSessions
                .FirstOrDefaultAsync(x => x.SessionId == sessionId);

        public async Task AddAsync(DefenseSession session)
        {
            await _context.DefenseSessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DefenseSession session)
        {
            _context.DefenseSessions.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DefenseSession session)
        {
            _context.DefenseSessions.Remove(session);
            await _context.SaveChangesAsync();
        }
    }
}
