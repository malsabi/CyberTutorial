using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IAnswerRepository : IRepository
    {
        Task AddAnswerAsync(Answer answer);
        Task<ICollection<Answer>> GetAnswersAsync();
        Task<ICollection<Answer>> GetAnswersByQuestionIdAsync(string questionId);
        Task<Answer> GetAnswerByIdAsync(string answerId);
        Task UpdateAnswerAsync(Answer answer);
        Task DeleteAnswersByQuestionIdAsync(string questionId);
        Task DeleteAnswerAsync(string answerId);
        Task DeleteAnswerAsync(Answer answer);
    }
}