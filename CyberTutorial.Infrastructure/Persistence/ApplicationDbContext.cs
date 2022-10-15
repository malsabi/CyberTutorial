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
        
        public DbSet<Company> Companies => Set<Company>();

        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<CompanySession> CompanySessions => Set<CompanySession>();

        public DbSet<EmployeeSession> EmployeeSessions => Set<EmployeeSession>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<EmployeeCourse> EmployeeCourses => Set<EmployeeCourse>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}