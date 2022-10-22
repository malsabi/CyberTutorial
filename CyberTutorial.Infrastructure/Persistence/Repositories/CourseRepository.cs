using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public CourseRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddCourseAsync(Course course)
        {
            await applicationDbContext.Courses.AddAsync(course);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task<ICollection<Course>> GetCoursesAsync()
        {
            return await applicationDbContext.Courses
                .Include(course => course.Employees)
                .Include(course => course.Quizzes)
                .ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(string courseId)
        {
            return await applicationDbContext.Courses
                .Include(course => course.Employees)
                .Include(course => course.Quizzes)
                .FirstOrDefaultAsync(course => course.CourseId == courseId);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            applicationDbContext.Courses.Update(course);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteCourseAsync(string courseId)
        {
            Course courseToDelete = await GetCourseByIdAsync(courseId);
            await DeleteCourseAsync(courseToDelete);
        }

        public async Task DeleteCourseAsync(Course course)
        {
            applicationDbContext.Courses.Remove(course);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.Courses.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}