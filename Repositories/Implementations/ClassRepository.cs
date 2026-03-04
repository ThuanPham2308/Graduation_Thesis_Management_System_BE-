using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public ClassRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAllAsync()
        {
            return await _context.Classes
                .Include(c => c.Lecturer)
                .ThenInclude(l => l.User)
                .ToListAsync();
        }

        public async Task<Class?> GetByIdAsync(string classId)
        {
            return await _context.Classes
                .Include(c => c.Lecturer)
                .ThenInclude(l => l.User)
                .FirstOrDefaultAsync(c => c.ClassId == classId);
        }

        public async Task AddAsync(Class classEntity)
        {
            await _context.Classes.AddAsync(classEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Class classEntity)
        {
            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Class classEntity)
        {
            _context.Classes.Remove(classEntity);
            await _context.SaveChangesAsync();
        }
    }
}
