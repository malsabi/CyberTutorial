using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Quizzes.Common
{
    public class GetQuizzesResult
    {
        public ICollection<Quiz> Quizzes { get; set; }
    }
}