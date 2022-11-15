using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public QuestionRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddQuestionAsync(Question question)
        {
            await applicationDbContext.Questions.AddAsync(question);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task<ICollection<Question>> GetQuestionsAsync()
        {
            return await applicationDbContext.Questions
                .Include(question => question.Answers)
                .Include(question => question.Quizzes)
                .Include(attempts => attempts.Attempts)
                .ToListAsync();
        }

        public async Task<ICollection<Question>> GetQuestionsByQuizIdAsync(string quizId)
        {
            return await applicationDbContext.Questions
                .Include(question => question.Answers)
                .Include(question => question.Quizzes)
                .Include(attempts => attempts.Attempts)
                .Where(question => question.Quizzes.Any(quiz => quiz.QuizId == quizId))
                .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(string questionId)
        {
            return await applicationDbContext.Questions
                .Include(question => question.Answers)
                .Include(question => question.Quizzes)
                .Include(attempts => attempts.Attempts)
                .FirstOrDefaultAsync(question => question.QuestionId == questionId);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            applicationDbContext.Questions.Update(question);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteQuestionsByQuizIdAsync(string quizId)
        {
            ICollection<Question> questionsToDelete = await GetQuestionsByQuizIdAsync(quizId);
            applicationDbContext.Questions.RemoveRange(questionsToDelete);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(string questionId)
        {
            Question questionToRemove = await GetQuestionByIdAsync(questionId);
            await DeleteQuestionAsync(questionToRemove);
        }
        
        public async Task DeleteQuestionAsync(Question question)
        {
            applicationDbContext.Questions.Remove(question);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.Questions.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}