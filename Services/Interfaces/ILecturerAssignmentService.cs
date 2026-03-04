using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerAssignmentDTOs;

namespace Graduation_Thesis_Management_System_BE.Services.Interfaces
{
    public interface ILecturerAssignmentService
    {
        Task<List<LecturerAssignmentDto>> GetByTopicAsync(string topicId);
        Task AssignAsync(CreateLecturerAssignmentDto dto);
        Task RemoveAsync(string topicId, string lecturerId, string role);
    }
}
