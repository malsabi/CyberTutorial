using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Quizzes.Common;

namespace CyberTutorial.Application.Quizzes.Commands.AddQuiz
{
    public class AddQuizCommand : IRequest<ErrorOr<AddQuizResult>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaximumScore { get; set; }
        public int TotalQuestions { get; set; }
        public string Duration { get; set; }
        public string CourseId { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}