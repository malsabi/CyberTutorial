namespace CyberTutorial.Domain.Entities
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseImage { get; set; }
        public string CourseName { get; set; }
        public string CourseDiscription { get; set; }
        public string CourseUrl { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}