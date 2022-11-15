using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.Domain.Entities
{
    public class Attempt
    {
        public string AttemptId { get; set; }
        public string EmployeeId { get; set; }
        public string QuizId { get; set; }
        public string QuizName { get; set; }
        public string StartedAt { get; set; }
        public string CompletedAt { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public int TotalIncorrectAnswers { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Quiz Quiz { get; set; }
        public ICollection<Question> AttemptedQuestions { get; set; }
    }
}