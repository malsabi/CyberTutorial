using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IQuestionRepository : IRepository
    {
        Task AddQuestionAsync(Question question);
        Task<ICollection<Question>> GetQuestionsAsync();
        Task<ICollection<Question>> GetQuestionsByQuizIdAsync(string quizId);
        Task<Question> GetQuestionByIdAsync(string questionId);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionsByQuizIdAsync(string quizId);
        Task DeleteQuestionAsync(string questionId);
        Task DeleteQuestionAsync(Question question);
    }
}