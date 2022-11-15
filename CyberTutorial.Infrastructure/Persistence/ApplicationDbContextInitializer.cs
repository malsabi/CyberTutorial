using CyberTutorial.Infrastructure.Persistence.Seeding;

namespace CyberTutorial.Infrastructure.Persistence
{
    public static class ApplicationDbContextInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(CourseSeeding.Courses());
                context.SaveChanges();
            }

            if (!context.Quizzes.Any())
            {
                context.Quizzes.AddRange(QuizSeeding.Quizzes());
                context.SaveChanges();
            }
        }
    }
}