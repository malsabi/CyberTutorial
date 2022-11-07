using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.Domain.Entities
{
    public class Quiz
    {
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaximumScore { get; set; }
        public int TotalQuestions { get; set; }
        public string Duration { get; set; }
        public string CourseId { get; set; }
        [Required]
        public Course Course { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}