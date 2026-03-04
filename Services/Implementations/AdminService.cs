using Graduation_Thesis_Management_System_BE.Models.Dtos.AdminDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepo;
        private readonly IUserRepository _userRepo;

        public AdminService(IAdminRepository adminRepo, IUserRepository userRepo)
        {
            _adminRepo = adminRepo;
            _userRepo = userRepo;
        }

        public async Task<List<AdminDto>> GetAllAsync()
        {
            var admins = await _adminRepo.GetAllAsync();

            return admins.Select(a => new AdminDto
            {
                AdminId = a.AdminId,
                UserId = a.UserId!,
                FullName = a.User!.FullName,
                Email = a.User.Email
            }).ToList();
        }

        public async Task CreateAsync(AdminCreateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(dto.UserId);

            if (user == null)
                throw new Exception("User không tồn tại");

            if (user.Role != "Quản trị")
                throw new Exception("User không có quyền Admin");

            var admin = new Admin
            {
                AdminId = Guid.NewGuid().ToString("N")[..20],
                UserId = dto.UserId
            };

            await _adminRepo.AddAsync(admin);
            await _adminRepo.SaveAsync();
        }

        public async Task DeleteAsync(string adminId)
        {
            var admin = await _adminRepo.GetByIdAsync(adminId);
            if (admin == null)
                throw new Exception("Admin không tồn tại");

            await _adminRepo.DeleteAsync(admin);
            await _adminRepo.SaveAsync();
        }
    }
}
