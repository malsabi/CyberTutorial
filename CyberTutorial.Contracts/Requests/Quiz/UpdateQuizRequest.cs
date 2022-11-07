using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Requests.Quiz
{
    public class UpdateQuizRequest
    {
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaximumScore { get; set; }
        public int TotalQuestions { get; set; }
        public string Duration { get; set; }
        public string CourseId { get; set; }
        public ICollection<QuestionModel> Questions { get; set; }
    }
}