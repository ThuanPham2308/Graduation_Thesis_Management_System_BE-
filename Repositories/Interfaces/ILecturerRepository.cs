using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface ILecturerRepository
    {
        Task<List<Lecturer>> GetAllAsync();
        Task<Lecturer?> GetByIdAsync(Guid lecturerId);
        Task AddAsync(Lecturer lecturer);
        Task UpdateAsync(Lecturer lecturer);
        Task DeleteAsync(Lecturer lecturer);
    }
}
