using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerAssignmentDTOs;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface ILecturerAssignmentService
    {
        Task<List<LecturerAssignmentDto>> GetByTopicAsync(Guid topicId);
        Task AssignAsync(CreateLecturerAssignmentDto dto);
        Task RemoveAsync(Guid topicId, Guid lecturerId, string role);
    }
}
