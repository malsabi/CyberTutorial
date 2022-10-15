namespace CyberTutorial.Domain.Entities
{
    public class Answer
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}