namespace CyberTutorial.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Answers { get; set; }
    }
}