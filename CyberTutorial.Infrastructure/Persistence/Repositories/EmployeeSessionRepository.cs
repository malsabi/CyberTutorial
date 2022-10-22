using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class EmployeeSessionRepository : IEmployeeSessionRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public EmployeeSessionRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddEmployeeSessionAsync(EmployeeSession session)
        {
            await applicationDbContext.EmployeeSessions.AddAsync(session);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<EmployeeSession>> GetEmployeeSessionsAsync()
        {
            return await applicationDbContext.EmployeeSessions
                .Include(emplyoeeSession => emplyoeeSession.Employee)
                .ToListAsync();
        }
        
        public async Task<EmployeeSession> GetEmployeeSessionByIdAsync(string employeeId)
        {
            return await applicationDbContext.EmployeeSessions
                .Include(emplyoeeSession => emplyoeeSession.Employee)
                .FirstOrDefaultAsync(employeeSession => employeeSession.EmployeeSessionId == employeeId);
        }

        public async Task<EmployeeSession> GetEmployeeSessionByTokenAsync(string token)
        {
            return await applicationDbContext.EmployeeSessions
                .Include(emplyoeeSession => emplyoeeSession.Employee)
                .FirstOrDefaultAsync(employeeSession => employeeSession.Token == token);
        }

        public async Task UpdateEmployeeSessionAsync(EmployeeSession session)
        {
            applicationDbContext.EmployeeSessions.Update(session);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeSessionAsync(string employeeId)
        {
            EmployeeSession employeeSessionToDelete = await GetEmployeeSessionByIdAsync(employeeId);
            await DeleteEmployeeSessionAsync(employeeSessionToDelete);
        }

        public async Task DeleteEmployeeSessionAsync(EmployeeSession session)
        {
            applicationDbContext.EmployeeSessions.Remove(session);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.EmployeeSessions.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}