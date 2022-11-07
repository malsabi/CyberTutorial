using ErrorOr;
using MediatR;
using CyberTutorial.Application.Attempts.Common;

namespace CyberTutorial.Application.Attempts.Commands.DeleteAttempt
{
    public class DeleteAttemptCommand : IRequest<ErrorOr<DeleteAttemptResult>>
    {
        public string AttemptId { get; set; }
    }
}