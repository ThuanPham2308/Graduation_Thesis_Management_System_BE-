using Graduation_Thesis_Management_System_BE.Models.Dtos.OutlinePlanDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class OutlinePlanService : IOutlinePlanService
    {
        private readonly IOutlinePlanRepository _repository;

        public OutlinePlanService(IOutlinePlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<OutlinePlanDto?> GetByTopicAsync(Guid topicId)
        {
            var entity = await _repository.GetByTopicAsync(topicId);
            if (entity == null) return null;

            return new OutlinePlanDto
            {
                OutlineId = entity.OutlineId,
                TopicId = entity.TopicId,
                OutlineContent = entity.OutlineContent,
                ExecutionPlan = entity.ExecutionPlan,
                SubmissionDate = entity.SubmissionDate,
                Note = entity.Note
            };
        }

        public async Task CreateAsync(CreateOutlinePlanDto dto)
        {
            var entity = new OutlinePlan
            {
                OutlineId = dto.OutlineId,
                TopicId = dto.TopicId,
                OutlineContent = dto.OutlineContent,
                ExecutionPlan = dto.ExecutionPlan,
                Note = dto.Note,
                SubmissionDate = DateTime.Now
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid outlineId, UpdateOutlinePlanDto dto)
        {
            var entity = await _repository.GetByIdAsync(outlineId);
            if (entity == null)
                throw new Exception("OutlinePlan not found");

            entity.OutlineContent = dto.OutlineContent;
            entity.ExecutionPlan = dto.ExecutionPlan;
            entity.Note = dto.Note;

            await _repository.UpdateAsync(entity);
        }
    }
}
