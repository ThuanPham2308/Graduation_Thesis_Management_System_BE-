using Graduation_Thesis_Management_System_BE.Models.Dtos.ResultDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _repo;

        public ResultService(IResultRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ResultDto>> GetAllAsync()
        {
            var results = await _repo.GetAllAsync();

            return results.Select(r => new ResultDto
            {
                ResultId = r.ResultId,
                TopicId = r.TopicId,
                ProcessScore = r.ProcessScore,
                DefenseScore = r.DefenseScore,
                Comment = r.Comment,
                EvaluationDate = r.EvaluationDate
            }).ToList();
        }

        public async Task<ResultDto?> GetByTopicIdAsync(Guid topicId)
        {
            var result = await _repo.GetByTopicIdAsync(topicId);
            if (result == null) return null;

            return new ResultDto
            {
                ResultId = result.ResultId,
                TopicId = result.TopicId,
                ProcessScore = result.ProcessScore,
                DefenseScore = result.DefenseScore,
                Comment = result.Comment,
                EvaluationDate = result.EvaluationDate
            };
        }

        public async Task CreateAsync(CreateResultDto dto)
        {
            var result = new Result
            {
                ResultId = dto.ResultId,
                TopicId = dto.TopicId,
                ProcessScore = dto.ProcessScore,
                DefenseScore = dto.DefenseScore,
                Comment = dto.Comment
            };

            await _repo.AddAsync(result);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(Guid topicId, UpdateResultDto dto)
        {
            var result = await _repo.GetByTopicIdAsync(topicId)
                ?? throw new Exception("Result not found");

            result.ProcessScore = dto.ProcessScore;
            result.DefenseScore = dto.DefenseScore;
            result.Comment = dto.Comment;
            result.EvaluationDate = DateTime.Now;

            await _repo.UpdateAsync(result);
            await _repo.SaveAsync();
        }
    }
}
