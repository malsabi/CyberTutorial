using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Attempts.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Attempts.Queries.GetAttemptById
{
    public class GetAttemptByIdQueryHandler : IRequestHandler<GetAttemptByIdQuery, ErrorOr<GetAttemptByIdResult>>
    {
        private readonly IMapper mapper;
        private readonly IAttemptRepository attemptRepository;

        public GetAttemptByIdQueryHandler(IMapper mapper, IAttemptRepository attemptRepository)
        {
            this.mapper = mapper;
            this.attemptRepository = attemptRepository;
        }

        public async Task<ErrorOr<GetAttemptByIdResult>> Handle(GetAttemptByIdQuery request, CancellationToken cancellationToken)
        {
            if (await attemptRepository.GetAttemptByIdAsync(request.AttemptId) is not Attempt attempt)
            {
                return Errors.Attempt.AttemptNotFound;
            }

            return mapper.Map<GetAttemptByIdResult>(attempt);
        }
    }
}