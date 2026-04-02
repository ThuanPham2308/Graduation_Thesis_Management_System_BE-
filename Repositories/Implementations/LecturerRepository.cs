using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{

    public class LecturerRepository : ILecturerRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public LecturerRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lecturer>> GetAllAsync()
        {
            return await _context.Lecturers
                .Include(l => l.User)
                .ToListAsync();
        }

        public async Task<Lecturer?> GetByIdAsync(Guid lecturerId)
        {
            return await _context.Lecturers
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.LecturerId == lecturerId);
        }

        public async Task AddAsync(Lecturer lecturer)
        {
            await _context.Lecturers.AddAsync(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lecturer lecturer)
        {
            _context.Lecturers.Update(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lecturer lecturer)
        {
            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
        }
    }
}
