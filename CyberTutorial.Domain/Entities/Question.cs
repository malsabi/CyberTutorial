namespace CyberTutorial.Domain.Entities
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}