using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Administrator> Administrators => Set<Administrator>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanySession> CompanySessions => Set<CompanySession>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeSession> EmployeeSessions => Set<EmployeeSession>();
        public DbSet<EmployeeDashboard> EmployeeDashboards => Set<EmployeeDashboard>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Quiz> Quizzes => Set<Quiz>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Answer> Answers => Set<Answer>();
 
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}