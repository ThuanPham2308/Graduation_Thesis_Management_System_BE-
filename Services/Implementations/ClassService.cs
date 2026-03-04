using Graduation_Thesis_Management_System_BE.Models.Dtos.ClassDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;

namespace Graduation_Thesis_Management_System_BE.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _repository;

        public ClassService(IClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClassDto>> GetAllAsync()
        {
            var classes = await _repository.GetAllAsync();

            return classes.Select(c => new ClassDto
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                Cohort = c.Cohort,
                AcademicYear = c.AcademicYear,
                Note = c.Note,
                LecturerId = c.LecturerId,
                LecturerName = c.Lecturer.User.FullName
            }).ToList();
        }

        public async Task<ClassDto?> GetByIdAsync(string classId)
        {
            var c = await _repository.GetByIdAsync(classId);
            if (c == null) return null;

            return new ClassDto
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                Cohort = c.Cohort,
                AcademicYear = c.AcademicYear,
                Note = c.Note,
                LecturerId = c.LecturerId,
                LecturerName = c.Lecturer.User.FullName
            };
        }

        public async Task CreateAsync(CreateClassDto dto)
        {
            var classEntity = new Class
            {
                ClassId = dto.ClassId,
                ClassName = dto.ClassName,
                Cohort = dto.Cohort,
                AcademicYear = dto.AcademicYear,
                Note = dto.Note,
                LecturerId = dto.LecturerId
            };

            await _repository.AddAsync(classEntity);
        }

        public async Task UpdateAsync(string classId, CreateClassDto dto)
        {
            var c = await _repository.GetByIdAsync(classId);
            if (c == null) throw new Exception("Class not found");

            c.ClassName = dto.ClassName;
            c.Cohort = dto.Cohort;
            c.AcademicYear = dto.AcademicYear;
            c.Note = dto.Note;
            c.LecturerId = dto.LecturerId;

            await _repository.UpdateAsync(c);
        }

        public async Task DeleteAsync(string classId)
        {
            var c = await _repository.GetByIdAsync(classId);
            if (c == null) throw new Exception("Class not found");

            await _repository.DeleteAsync(c);
        }
    }
}
