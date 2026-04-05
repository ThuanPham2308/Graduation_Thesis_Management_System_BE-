using Graduation_Thesis_Management_System_BE.Models.Dtos.StudentDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();

            return students.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                StudyYear = s.StudyYear ?? 1,
                UserId = s.UserId,
                FullName = s.User.FullName,
                ClassId = s.ClassId,
                ClassName = s.Class.ClassName
            }).ToList();
        }

        public async Task<StudentDto?> GetByIdAsync(Guid studentId)
        {
            var s = await _repository.GetByIdAsync(studentId);
            if (s == null) return null;

            return new StudentDto
            {
                StudentId = s.StudentId,
                StudyYear = s.StudyYear ?? 1,
                UserId = s.UserId,
                FullName = s.User.FullName,
                ClassId = s.ClassId,
                ClassName = s.Class.ClassName
            };
        }

        public async Task CreateAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                StudentId = dto.StudentId,
                StudyYear = dto.StudyYear,
                UserId = dto.UserId,
                ClassId = dto.ClassId
            };

            await _repository.AddAsync(student);
        }

        public async Task UpdateAsync(Guid studentId, CreateStudentDto dto)
        {
            var s = await _repository.GetByIdAsync(studentId);
            if (s == null) throw new Exception("Student not found");

            s.StudyYear = dto.StudyYear;
            s.UserId = dto.UserId;
            s.ClassId = dto.ClassId;

            await _repository.UpdateAsync(s);
        }

        public async Task DeleteAsync(Guid studentId)
        {
            var s = await _repository.GetByIdAsync(studentId);
            if (s == null) throw new Exception("Student not found");

            await _repository.DeleteAsync(s);
        }
    }
}
