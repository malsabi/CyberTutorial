using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Quizzes.Common;

namespace CyberTutorial.Application.Quizzes.Commands.UpdateQuiz
{
    public class UpdateQuizCommand : IRequest<ErrorOr<UpdateQuizResult>>
    {
        public string TargetId { get; set; }
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaximumScore { get; set; }
        public int TotalQuestions { get; set; }
        public string Duration { get; set; }
        public string CourseId { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}