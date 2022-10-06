using CyberTutorial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Application.Common.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; }

        DbSet<Employee> Employees { get; }

        DbSet<CompanySession> CompanySessions { get; }

        DbSet<EmployeeSession> EmployeeSessions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}