using Graduation_Thesis_Management_System_BE.Models.Dtos.DefenseSessionDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class DefenseSessionService : IDefenseSessionService
    {
        private readonly IDefenseSessionRepository _repository;

        public DefenseSessionService(IDefenseSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DefenseSessionDto>> GetAllAsync()
        {
            var sessions = await _repository.GetAllAsync();

            return sessions.Select(s => new DefenseSessionDto
            {
                SessionId = s.SessionId,
                SessionName = s.SessionName,
                AcademicYear = s.AcademicYear,
                Semester = s.Semester,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Note = s.Note
            }).ToList();
        }

        public async Task<DefenseSessionDto?> GetByIdAsync(Guid sessionId)
        {
            var s = await _repository.GetByIdAsync(sessionId);
            if (s == null) return null;

            return new DefenseSessionDto
            {
                SessionId = s.SessionId,
                SessionName = s.SessionName,
                AcademicYear = s.AcademicYear,
                Semester = s.Semester,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Note = s.Note
            };
        }

        public async Task CreateAsync(CreateDefenseSessionDto dto)
        {
            if (dto.EndDate <= dto.StartDate)
                throw new Exception("EndDate must be greater than StartDate");

            var session = new DefenseSession
            {
                SessionId = dto.SessionId,
                SessionName = dto.SessionName,
                AcademicYear = dto.AcademicYear,
                Semester = dto.Semester,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Note = dto.Note
            };

            await _repository.AddAsync(session);
        }

        public async Task UpdateAsync(Guid sessionId, CreateDefenseSessionDto dto)
        {
            var s = await _repository.GetByIdAsync(sessionId);
            if (s == null) throw new Exception("Defense session not found");

            s.SessionName = dto.SessionName;
            s.AcademicYear = dto.AcademicYear;
            s.Semester = dto.Semester;
            s.StartDate = dto.StartDate;
            s.EndDate = dto.EndDate;
            s.Note = dto.Note;

            await _repository.UpdateAsync(s);
        }

        public async Task DeleteAsync(Guid sessionId)
        {
            var s = await _repository.GetByIdAsync(sessionId);
            if (s == null) throw new Exception("Defense session not found");

            await _repository.DeleteAsync(s);
        }
    }
}
