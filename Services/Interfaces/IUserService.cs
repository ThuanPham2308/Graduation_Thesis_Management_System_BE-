using Graduation_Thesis_Management_System_BE.Models.Dtos.UserDTos;
using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateUserDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateUserDto dto); 
        Task<bool> DeleteAsync(Guid id);                      
        Task<User?> LoginAsync(string username, string password);
    }
}
