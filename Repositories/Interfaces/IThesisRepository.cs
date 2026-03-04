using Graduation_Thesis_Management_System_BE.Models.Entities;

namespace Graduation_Thesis_Management_System_BE.Repositories.Interfaces
{
    public interface IThesisRepository
    {
        Task<Thesis?> GetByTopicAsync(string topicId);
        Task<Thesis?> GetByIdAsync(string thesisId);
        Task AddAsync(Thesis thesis);
        Task UpdateAsync(Thesis thesis);
    }
}
