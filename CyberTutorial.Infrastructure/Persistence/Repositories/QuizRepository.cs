using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public QuizRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            await applicationDbContext.Quizzes.AddAsync(quiz);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Quiz>> GetQuizzesAsync()
        {
            return await applicationDbContext.Quizzes
                .Include(quiz => quiz.Employees)
                .Include(quiz => quiz.Course)
                .Include(quiz => quiz.Questions)
                .ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(string quizId)
        {
            return await applicationDbContext.Quizzes
                .Include(quiz => quiz.Employees)
                .Include(quiz => quiz.Course)
                .Include(quiz => quiz.Questions)
                .FirstOrDefaultAsync(quiz => quiz.QuizId == quizId);
        }

        public async Task<Quiz> GetQuizByCourseIdAsync(string courseId)
        {
            return await applicationDbContext.Quizzes
                .Include(quiz => quiz.Employees)
                .Include(quiz => quiz.Course)
                .Include(quiz => quiz.Questions)
                .FirstOrDefaultAsync(quiz => quiz.Course.CourseId == courseId);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            applicationDbContext.Quizzes.Update(quiz);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteQuizAsync(string quizId)
        {
            Quiz quizToDelete = await GetQuizByIdAsync(quizId);
            await DeleteQuizAsync(quizToDelete);
        }

        public async Task DeleteQuizAsync(Quiz quiz)
        {
            applicationDbContext.Quizzes.Remove(quiz);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.Quizzes.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}