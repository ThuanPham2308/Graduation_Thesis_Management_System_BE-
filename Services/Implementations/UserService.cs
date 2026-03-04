using Graduation_Thesis_Management_System_BE.Models.Dtos.UserDTos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        // XEM DANH SÁCH
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();

            return users.Select(u => new UserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Role = u.Role
            }).ToList();
        }

        // XEM CHI TIẾT
        public async Task<UserDto?> GetByIdAsync(string id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
        }

        // THÊM
        public async Task CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Address = dto.Address,
                Hometown = dto.Hometown,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName,
                Password = dto.Password, // (sau này hash)
                Role = dto.Role
            };

            await _repo.AddAsync(user);
        }

        // SỬA
        public async Task<bool> UpdateAsync(string id, UpdateUserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            user.FullName = dto.FullName;
            user.DateOfBirth = dto.DateOfBirth;
            user.Gender = dto.Gender;
            user.Address = dto.Address;
            user.Hometown = dto.Hometown;
            user.PhoneNumber = dto.PhoneNumber;
            user.Role = dto.Role;

            await _repo.UpdateAsync(user);
            return true;
        }

        // XÓA
        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            await _repo.DeleteAsync(user);
            return true;
        }
    }
}
