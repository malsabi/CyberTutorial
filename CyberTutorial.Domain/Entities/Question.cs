namespace CyberTutorial.Domain.Entities
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}