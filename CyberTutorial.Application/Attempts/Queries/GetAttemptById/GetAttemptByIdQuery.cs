using ErrorOr;
using MediatR;
using CyberTutorial.Application.Attempts.Common;

namespace CyberTutorial.Application.Attempts.Queries.GetAttemptById
{
    public class GetAttemptByIdQuery : IRequest<ErrorOr<GetAttemptByIdResult>>
    {
        public string AttemptId { get; set; }
    }
}