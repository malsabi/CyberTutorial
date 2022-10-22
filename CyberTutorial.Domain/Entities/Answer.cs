namespace CyberTutorial.Domain.Entities
{
    public class Answer
    {
        public string AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}