using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Attempts.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Attempts.Commands.AddAttempt
{
    public class AddAttemptCommandHandler : IRequestHandler<AddAttemptCommand, ErrorOr<AddAttemptResult>>
    {
        private readonly IMapper mapper;
        private readonly IAttemptRepository attemptRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IQuizRepository quizRepository;
        
        public AddAttemptCommandHandler(IMapper mapper, IAttemptRepository attemptRepository, IEmployeeRepository employeeRepository, IQuizRepository quizRepository)
        {
            this.mapper = mapper;
            this.attemptRepository = attemptRepository;
            this.employeeRepository = employeeRepository;
            this.quizRepository = quizRepository;
        }

        public async Task<ErrorOr<AddAttemptResult>> Handle(AddAttemptCommand request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is null)
            {
                return Errors.Employee.NotFound;
            }

            if (await quizRepository.GetQuizByIdAsync(request.QuizId) is null)
            {
                return Errors.Quiz.QuizNotFound;
            }

            Attempt attempt = mapper.Map<Attempt>(request);
            attempt.AttemptId = Guid.NewGuid().ToString();

            await attemptRepository.AddAttemptAsync(attempt);

            return mapper.Map<AddAttemptResult>(attempt);
        }
    }
}