using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public AnswerRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            await applicationDbContext.Answers.AddAsync(answer);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Answer>> GetAnswersAsync()
        {
            return await applicationDbContext.Answers
                .Include(answer => answer.Questions)
                .ToListAsync();
        }
        
        public async Task<ICollection<Answer>> GetAnswersByQuestionIdAsync(string questionId)
        {
            return await applicationDbContext.Answers
                .Include(answer => answer.Questions)
                .Where(answer => answer.Questions.Any(question => question.QuestionId == questionId))
                .ToListAsync();
        }
        
        public async Task<Answer> GetAnswerByIdAsync(string answerId)
        {
            return await applicationDbContext.Answers
                .Include(answer => answer.Questions)
                .FirstOrDefaultAsync(answer => answer.AnswerId == answerId);            
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            applicationDbContext.Answers.Update(answer);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAnswersByQuestionIdAsync(string questionId)
        {
            ICollection<Answer> answersToDelete = await GetAnswersByQuestionIdAsync(questionId);
            applicationDbContext.Answers.RemoveRange(answersToDelete);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAnswerAsync(string answerId)
        {
            Answer answerToDelete = await GetAnswerByIdAsync(answerId);
            await DeleteAnswerAsync(answerToDelete);
        }

        public async Task DeleteAnswerAsync(Answer answer)
        {
            applicationDbContext.Answers.Remove(answer);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAllAsync()
        {
            applicationDbContext.Answers.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}