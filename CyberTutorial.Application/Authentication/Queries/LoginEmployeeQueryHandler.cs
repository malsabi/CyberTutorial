using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Queries
{
    public class LoginEmployeeQueryHandler : IRequestHandler<LoginEmployeeQuery, ErrorOr<LoginResult>>
    {
        private readonly IMapper mapper;
        private readonly IHashProvider hashProvider;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeSessionRepository employeeSessionRepository;

        public LoginEmployeeQueryHandler(IMapper mapper, IHashProvider hashProvider, IJwtTokenGenerator jwtTokenGenerator, 
            IEmployeeRepository employeeRepository, IEmployeeSessionRepository employeeSessionRepository)
        {
            this.mapper = mapper;
            this.hashProvider = hashProvider;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.employeeRepository = employeeRepository;
            this.employeeSessionRepository = employeeSessionRepository;
        }

        public async Task<ErrorOr<LoginResult>> Handle(LoginEmployeeQuery command, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByEmailAsync(command.EmailAddress) is not Employee employee)
            {
                return Errors.Authentication.DoesNotExists;
            }

            if (!hashProvider.VarifyHash(employee.Password, command.Password))
            {
                return Errors.Authentication.InvalidPassword;
            }

            if (await employeeSessionRepository.GetEmployeeSessionByEmployeeIdAsync(employee.Id) is EmployeeSession existingEmployeeSession)
            {
                await employeeSessionRepository.DeleteEmployeeSessionAsync(existingEmployeeSession);
            }

            EmployeeSession employeeSession = new EmployeeSession()
            {
                Id = Guid.NewGuid().ToString(),
                EmployeeId = employee.Id,
                TimeCreated = DateTime.Now.ToString(),
                ExpiryDate = DateTime.Now.AddDays(30).ToString(),
                Token = jwtTokenGenerator.GenerateToken(employee),
                IsActive = true
            };

            await employeeSessionRepository.CreateEmployeeSessionAsync(employeeSession);

            return new LoginResult()
            {
                SessionId = employeeSession.Id,
                Token = employeeSession.Token
            };
        }
    }
}