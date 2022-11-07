using ErrorOr;
using MediatR;
using CyberTutorial.Application.Quizzes.Common;

namespace CyberTutorial.Application.Quizzes.Queries.GetQuizById
{
    public class GetQuizByIdQuery : IRequest<ErrorOr<GetQuizByIdResult>>
    {
        public string QuizId { get; set; }
    }
}