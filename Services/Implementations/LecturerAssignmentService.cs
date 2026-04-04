using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerAssignmentDTOs;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class LecturerAssignmentService : ILecturerAssignmentService
    {
        private readonly ILecturerAssignmentRepository _repository;

        public LecturerAssignmentService(ILecturerAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LecturerAssignmentDto>> GetByTopicAsync(Guid topicId)
        {
            var list = await _repository.GetByTopicAsync(topicId);

            return list.Select(x => new LecturerAssignmentDto
            {
                TopicId = x.TopicId,
                LecturerId = x.LecturerId,
                Role = x.Role
            }).ToList();
        }

        public async Task AssignAsync(CreateLecturerAssignmentDto dto)
        {
            var entity = new LecturerAssignment
            {
                TopicId = dto.TopicId,
                LecturerId = dto.LecturerId,
                Role = dto.Role
            };

            await _repository.AddAsync(entity);
        }

        public async Task RemoveAsync(Guid topicId, Guid lecturerId, string role)
        {
            await _repository.DeleteAsync(topicId, lecturerId, role);
        }
    }
}
