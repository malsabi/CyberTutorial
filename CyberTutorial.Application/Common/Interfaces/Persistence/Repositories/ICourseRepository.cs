using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface ICourseRepository : IRepository
    {
        Task AddCourseAsync(Course course);
        Task<ICollection<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(string courseId);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(string courseId);
        Task DeleteCourseAsync(Course course);
    }
}