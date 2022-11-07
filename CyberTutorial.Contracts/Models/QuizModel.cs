namespace CyberTutorial.Contracts.Models
{
    public class QuizModel
    {
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaximumScore { get; set; }
        public int TotalQuestions { get; set; }
        public string Duration { get; set; }
        public string CourseId { get; set; }
        public ICollection<QuestionModel> Questions { get; set; }
        public ICollection<AttemptModel> Attempts { get; set; }
    }
}