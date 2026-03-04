using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface ILecturerAssignmentRepository
    {
        Task<List<LecturerAssignment>> GetByTopicAsync(string topicId);
        Task AddAsync(LecturerAssignment assignment);
        Task DeleteAsync(string topicId, string lecturerId, string role);
    }
}
