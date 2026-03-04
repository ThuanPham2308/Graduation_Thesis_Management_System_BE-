using Graduation_Thesis_Management_System_BE.Models.Dtos.UserDTos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(string id);
        Task CreateAsync(CreateUserDto dto);
        Task<bool> UpdateAsync(string id, UpdateUserDto dto);
        Task<bool> DeleteAsync(string id);
    }
}
