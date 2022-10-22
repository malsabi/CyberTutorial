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
        public virtual ICollection<Employee> Employees { get; set; }
        [Required]
        public virtual Course Course { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}