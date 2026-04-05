using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Graduation_Thesis_Management_System_BE.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly GraduationThesisManagementSystemDbContext _context;

        public AdminRepository(GraduationThesisManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            return await _context.Admins
                .Include(a => a.User)
                .ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(string adminId)
        {
            if (!Guid.TryParse(adminId, out var guid))
                return null;

            return await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminId == guid);
        }

        public async Task AddAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
        }

        public async Task DeleteAsync(Admin admin)
        {
            _context.Admins.Remove(admin);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
