using Graduation_Thesis_Management_System_BE.Models.Dtos.DefenseSessionDtos;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface IDefenseSessionService
    {
        Task<List<DefenseSessionDto>> GetAllAsync();
        Task<DefenseSessionDto?> GetByIdAsync(Guid sessionId);
        Task CreateAsync(CreateDefenseSessionDto dto);
        Task UpdateAsync(Guid sessionId, CreateDefenseSessionDto dto);
        Task DeleteAsync(Guid sessionId);
    }
}
