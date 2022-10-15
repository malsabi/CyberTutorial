using CyberTutorial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Application.Common.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Administrator> Administrators { get; }

        public DbSet<Company> Companies { get; }

        public DbSet<Employee> Employees { get; }

        public DbSet<CompanySession> CompanySessions { get; }

        public DbSet<EmployeeSession> EmployeeSessions { get; }

        public DbSet<Course> Courses { get; }

        public DbSet<EmployeeCourse> EmployeeCourses { get; }

        public DbSet<Quiz> Quizzes { get; }

        public DbSet<Question> Questions { get; }

        public DbSet<EmployeeQuiz> EmployeeQuizzes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}