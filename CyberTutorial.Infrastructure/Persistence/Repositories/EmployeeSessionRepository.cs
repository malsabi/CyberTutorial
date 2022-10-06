using CyberTutorial.Domain.Entities;
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

        public async Task CreateEmployeeSessionAsync(EmployeeSession employeeSession)
        {
            await applicationDbContext.EmployeeSessions.AddAsync(employeeSession);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeSessionAsync(EmployeeSession employeeSession)
        {
            applicationDbContext.EmployeeSessions.Remove(employeeSession);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<EmployeeSession> GetEmployeeSessionByEmployeeIdAsync(string employeeId)
        {
            EmployeeSession employeeSession = await applicationDbContext.EmployeeSessions.FirstOrDefaultAsync(session => session.EmployeeId == employeeId);
            return employeeSession;
        }

        public async Task<EmployeeSession> GetEmployeeSessionBySessionIdAsync(string sessionId)
        {
            EmployeeSession employeeSession = await applicationDbContext.EmployeeSessions.FirstOrDefaultAsync(session => session.Id == sessionId);
            return employeeSession;
        }

        public async Task<EmployeeSession> GetEmployeeSessionByTokenAsync(string token)
        {
            EmployeeSession employeeSession = await applicationDbContext.EmployeeSessions.FirstOrDefaultAsync(session => session.Token == token);
            return employeeSession;
        }

        public async Task UpdateEmployeeSessionAsync(EmployeeSession employeeSession)
        {
            applicationDbContext.EmployeeSessions.Update(employeeSession);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}