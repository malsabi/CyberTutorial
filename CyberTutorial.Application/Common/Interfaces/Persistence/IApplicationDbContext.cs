using CyberTutorial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Application.Common.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Administrator> Administrators { get; }
        public DbSet<Company> Companies { get; }
        public DbSet<CompanySession> CompanySessions { get; }
        public DbSet<Employee> Employees { get; }
        public DbSet<Attempt> Attempts { get; }
        public DbSet<EmployeeSession> EmployeeSessions { get; }
        public DbSet<EmployeeDashboard> EmployeeDashboards { get; }
        public DbSet<TopEmployee> TopEmployees { get; }
        public DbSet<Course> Courses { get; }
        public DbSet<Quiz> Quizzes { get; }
        public DbSet<Question> Questions { get; }
        public DbSet<Answer> Answers { get; }
        public DbSet<Document> Documents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}