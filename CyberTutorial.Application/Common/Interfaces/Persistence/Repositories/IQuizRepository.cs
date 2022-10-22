using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IQuizRepository : IRepository
    {
        Task AddQuizAsync(Quiz quiz);
        Task<ICollection<Quiz>> GetQuizzesAsync();
        Task<Quiz> GetQuizByIdAsync(string quizId);
        Task<Quiz> GetQuizByCourseIdAsync(string courseId);
        Task UpdateQuizAsync(Quiz quiz);
        Task DeleteQuizAsync(string quizId);
        Task DeleteQuizAsync(Quiz quiz);
    }
}