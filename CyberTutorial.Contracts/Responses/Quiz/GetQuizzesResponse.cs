using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Quiz
{
    public class GetQuizzesResponse
    {
        public ICollection<QuizModel> Quizzes { get; set; }
    }
}