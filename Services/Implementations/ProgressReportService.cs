using Graduation_Thesis_Management_System_BE.Models.Dtos.ProgressReportDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class ProgressReportService : IProgressReportService
    {
        private readonly IProgressReportRepository _repository;

        public ProgressReportService(IProgressReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProgressReportDto>> GetByTopicAsync(Guid topicId)
        {
            var list = await _repository.GetByTopicAsync(topicId);

            return list.Select(x => new ProgressReportDto
            {
                ReportId = x.ReportId,
                TopicId = x.TopicId,
                ReportContent = x.ReportContent,
                FilePath = x.FilePath,
                UpdatedDate = x.UpdatedDate,
                Comment = x.Comment
            }).ToList();
        }

        public async Task CreateAsync(CreateProgressReportDto dto)
        {
            var entity = new ProgressReport
            {
                ReportId = dto.ReportId,
                TopicId = dto.TopicId,
                ReportContent = dto.ReportContent,
                FilePath = dto.FilePath,
                UpdatedDate = DateTime.Now
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid reportId, UpdateProgressReportDto dto)
        {
            var entity = await _repository.GetByIdAsync(reportId);
            if (entity == null)
                throw new Exception("ProgressReport not found");

            entity.ReportContent = dto.ReportContent;
            entity.FilePath = dto.FilePath;
            entity.Comment = dto.Comment;
            entity.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }
    }
}
