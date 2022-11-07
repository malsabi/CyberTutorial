using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Attempts.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Attempts.Commands.UpdateAttempt
{
    public class UpdateAttemptCommandHandler : IRequestHandler<UpdateAttemptCommand, ErrorOr<UpdateAttemptResult>>
    {
        private readonly IMapper mapper;
        private readonly IAttemptRepository attemptRepository;

        public UpdateAttemptCommandHandler(IMapper mapper, IAttemptRepository attemptRepository)
        {
            this.mapper = mapper;
            this.attemptRepository = attemptRepository;
        }

        public async Task<ErrorOr<UpdateAttemptResult>> Handle(UpdateAttemptCommand request, CancellationToken cancellationToken)
        {
            if (await attemptRepository.GetAttemptByIdAsync(request.AttemptId) is not Attempt attempt)
            {
                return Errors.Attempt.AttemptNotFound;
            }

            attempt.EmployeeId = request.EmployeeId;
            attempt.QuizId = request.QuizId;
            attempt.StartedAt = request.StartedAt;
            attempt.CompletedAt = request.CompletedAt;
            attempt.IsStarted = request.IsStarted;
            attempt.IsCompleted = request.IsCompleted;
            attempt.Score = request.Score;
            attempt.TotalCorrectAnswers = request.TotalCorrectAnswers;
            attempt.TotalIncorectAnswers = request.TotalIncorectAnswers;

            await attemptRepository.UpdateAttemptAsync(attempt);

            return mapper.Map<UpdateAttemptResult>(attempt);
        }
    }
}