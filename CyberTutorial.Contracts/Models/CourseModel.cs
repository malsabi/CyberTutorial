namespace CyberTutorial.Contracts.Models
{
    public class CourseModel
    {
        public string CourseId { get; set; }
        public string CourseImage { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseUrl { get; set; }
        public ICollection<QuizModel> Quizzes { get; set; }
    }
}