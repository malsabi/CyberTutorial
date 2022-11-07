using MediatR;
using CyberTutorial.Application.Attempts.Common;

namespace CyberTutorial.Application.Attempts.Queries.GetAttempts
{
    public class GetAttemptsQuery : IRequest<GetAttemptsResult>
    {
    }
}