using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Attempts.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Attempts.Commands.DeleteAttempt
{
    public class DeleteAttemptCommandHandler : IRequestHandler<DeleteAttemptCommand, ErrorOr<DeleteAttemptResult>>
    {
        private readonly IMapper mapper;
        private readonly IAttemptRepository attemptRepository;

        public DeleteAttemptCommandHandler(IAttemptRepository attemptRepository, IMapper mapper)
        {
            this.attemptRepository = attemptRepository;
            this.mapper = mapper;
        }

        public async Task<ErrorOr<DeleteAttemptResult>> Handle(DeleteAttemptCommand request, CancellationToken cancellationToken)
        {
            if (await attemptRepository.GetAttemptByIdAsync(request.AttemptId) is not Attempt attempt)
            {
                return Errors.Attempt.AttemptNotFound;
            }

            await attemptRepository.DeleteAttemptAsync(attempt);

            return mapper.Map<DeleteAttemptResult>(attempt);
        }
    }
}