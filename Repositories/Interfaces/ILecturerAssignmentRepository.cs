using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface ILecturerAssignmentRepository
    {
        Task<List<LecturerAssignment>> GetByTopicAsync(Guid topicId);
        Task AddAsync(LecturerAssignment assignment);
        Task DeleteAsync(Guid topicId, Guid lecturerId, string role);
    }
}
