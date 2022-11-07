namespace CyberTutorial.Domain.Entities
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseImage { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseUrl { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}