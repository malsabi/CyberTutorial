using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IAttemptRepository
    {
        Task AddAttemptAsync(Attempt attempt);
        Task<ICollection<Attempt>> GetAttemptsAsync();
        Task<Attempt> GetAttemptByIdAsync(string attemptId);
        Task UpdateAttemptAsync(Attempt attempt);
        Task DeleteAttemptAsync(string attemptId);
        Task DeleteAttemptAsync(Attempt attempt);
    }
}