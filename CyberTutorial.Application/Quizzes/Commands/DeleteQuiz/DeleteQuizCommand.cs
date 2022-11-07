using ErrorOr;
using MediatR;
using CyberTutorial.Application.Quizzes.Common;

namespace CyberTutorial.Application.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommand : IRequest<ErrorOr<DeleteQuizResult>>
    { 
        public string QuizId { get; set; }
    }
}