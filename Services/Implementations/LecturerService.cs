using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _repository;

        public LecturerService(ILecturerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LecturerDto>> GetAllAsync()
        {
            var lecturers = await _repository.GetAllAsync();

            return lecturers.Select(l => new LecturerDto
            {
                LecturerId = l.LecturerId,
                Position = l.Position,
                Specialization = l.Specialization,
                AcademicDegree = l.AcademicDegree,
                UserId = l.UserId,
                FullName = l.User.FullName,
                Email = l.User.Email
            }).ToList();
        }

        public async Task<LecturerDto?> GetByIdAsync(string lecturerId)
        {
            var l = await _repository.GetByIdAsync(lecturerId);
            if (l == null) return null;

            return new LecturerDto
            {
                LecturerId = l.LecturerId,
                Position = l.Position,
                Specialization = l.Specialization,
                AcademicDegree = l.AcademicDegree,
                UserId = l.UserId,
                FullName = l.User.FullName,
                Email = l.User.Email
            };
        }

        public async Task CreateAsync(CreateLecturerDto dto)
        {
            var lecturer = new Lecturer
            {
                LecturerId = dto.LecturerId,
                Position = dto.Position,
                Specialization = dto.Specialization,
                AcademicDegree = dto.AcademicDegree,
                UserId = dto.UserId
            };

            await _repository.AddAsync(lecturer);
        }

        public async Task UpdateAsync(string lecturerId, CreateLecturerDto dto)
        {
            var lecturer = await _repository.GetByIdAsync(lecturerId);
            if (lecturer == null) throw new Exception("Lecturer not found");

            lecturer.Position = dto.Position;
            lecturer.Specialization = dto.Specialization;
            lecturer.AcademicDegree = dto.AcademicDegree;
            lecturer.UserId = dto.UserId;

            await _repository.UpdateAsync(lecturer);
        }

        public async Task DeleteAsync(string lecturerId)
        {
            var lecturer = await _repository.GetByIdAsync(lecturerId);
            if (lecturer == null) throw new Exception("Lecturer not found");

            await _repository.DeleteAsync(lecturer);
        }
    }
}
