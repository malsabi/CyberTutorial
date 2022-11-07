using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Attempts.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Attempts.Queries.GetAttempts
{
    public class GetAttemptsQueryHandler : IRequestHandler<GetAttemptsQuery, GetAttemptsResult>
    {
        private readonly IAttemptRepository attemptRepository;

        public GetAttemptsQueryHandler(IAttemptRepository attemptRepository)
        {
            this.attemptRepository = attemptRepository;
        }

        public async Task<GetAttemptsResult> Handle(GetAttemptsQuery request, CancellationToken cancellationToken)
        {
            ICollection<Attempt> attempts = await attemptRepository.GetAttemptsAsync();
            return new GetAttemptsResult()
            {
                Attempts = attempts
            };
        }
    }
}