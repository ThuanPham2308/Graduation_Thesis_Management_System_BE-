using Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class ThesisService : IThesisService
    {
        private readonly IThesisRepository _repository;

        public ThesisService(IThesisRepository repository)
        {
            _repository = repository;
        }

        public async Task<ThesisDto?> GetByTopicAsync(Guid topicId)
        {
            var entity = await _repository.GetByTopicAsync(topicId);
            if (entity == null) return null;

            return new ThesisDto
            {
                ThesisId = entity.ThesisId,
                TopicId = entity.TopicId,
                SubmissionDate = entity.SubmissionDate,
                FilePath = entity.FilePath,
                Description = entity.Description,
                ApprovalStatus = entity.ApprovalStatus,
                DefenseConfirmation = entity.DefenseConfirmation,
                DefenseStatus = entity.DefenseStatus,
                ApprovalDate = entity.ApprovalDate
            };
        }

        public async Task CreateAsync(CreateThesisDto dto)
        {
            var entity = new Thesis
            {
                ThesisId = dto.ThesisId,
                TopicId = dto.TopicId,
                FilePath = dto.FilePath,
                Description = dto.Description,
                SubmissionDate = DateTime.Now,
                ApprovalStatus = "Chờ duyệt",
                DefenseConfirmation = "Chờ duyệt",
                DefenseStatus = "Đang bảo vệ"
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid thesisId, UpdateThesisDto dto)
        {
            var entity = await _repository.GetByIdAsync(thesisId);
            if (entity == null)
                throw new Exception("Thesis not found");

            entity.FilePath = dto.FilePath;
            entity.Description = dto.Description;
            entity.SubmissionDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }

        public async Task ApproveAsync(Guid thesisId, ApproveThesisDto dto)
        {
            var entity = await _repository.GetByIdAsync(thesisId);
            if (entity == null)
                throw new Exception("Thesis not found");

            entity.ApprovalStatus = dto.ApprovalStatus;
            entity.DefenseConfirmation = dto.DefenseConfirmation;
            entity.ApprovalDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }
    }
}
