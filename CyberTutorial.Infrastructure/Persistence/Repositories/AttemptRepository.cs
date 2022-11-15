using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class AttemptRepository : IAttemptRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public AttemptRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddAttemptAsync(Attempt attempt)
        {
            await applicationDbContext.Attempts.AddAsync(attempt);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Attempt>> GetAttemptsAsync()
        {
            return await applicationDbContext.Attempts
                .Include(attempt => attempt.Employee)
                .Include(attempt => attempt.Quiz)
                .Include(attempt => attempt.AttemptedQuestions)
                .ThenInclude(answers => answers.Answers)
                .ToListAsync();
        }

        public async Task<Attempt> GetAttemptByIdAsync(string attemptId)
        {
            return await applicationDbContext.Attempts
                .Include(attempt => attempt.Employee)
                .Include(attempt => attempt.Quiz)
                .Include(attempt => attempt.AttemptedQuestions)
                .ThenInclude(answers => answers.Answers)
                .FirstOrDefaultAsync(attempt => attempt.AttemptId == attemptId);
        }

        public async Task UpdateAttemptAsync(Attempt attempt)
        {
            applicationDbContext.Attempts.Update(attempt);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAttemptAsync(string attemptId)
        {
            Attempt attemptToDelete = await GetAttemptByIdAsync(attemptId);
            await DeleteAttemptAsync(attemptToDelete);
        }

        public async Task DeleteAttemptAsync(Attempt attempt)
        {
            applicationDbContext.Attempts.Remove(attempt);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}