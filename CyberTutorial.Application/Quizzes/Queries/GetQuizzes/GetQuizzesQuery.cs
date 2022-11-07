using MediatR;
using CyberTutorial.Application.Quizzes.Common;

namespace CyberTutorial.Application.Quizzes.Queries.GetQuizzes
{
    public class GetQuizzesQuery : IRequest<GetQuizzesResult>
    {
    }
}