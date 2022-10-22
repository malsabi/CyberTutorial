using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Queries.Login
{
    public class LoginEmployeeQueryHandler : IRequestHandler<LoginEmployeeQuery, ErrorOr<LoginResult>>
    {
        private readonly IHashProvider hashProvider;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IEmployeeRepository employeeRepository;

        public LoginEmployeeQueryHandler(IHashProvider hashProvider, IJwtTokenGenerator jwtTokenGenerator, IEmployeeRepository employeeRepository)
        {
            this.hashProvider = hashProvider;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.employeeRepository = employeeRepository;
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

            if (employee.Session == null)
            {
                employee.Session = new EmployeeSession()
                {
                    TimeCreated = DateTime.Now.ToString(),
                    ExpiryDate = DateTime.Now.AddDays(30).ToString(),
                    Token = jwtTokenGenerator.GenerateToken(employee),
                    IsActive = true
                };
            }
            else
            {
                employee.Session.ExpiryDate = DateTime.Now.AddDays(30).ToString();
                employee.Session.Token = jwtTokenGenerator.GenerateToken(employee);
                employee.Session.IsActive = true;
            }

            await employeeRepository.UpdateEmployeeAsync(employee);

            return new LoginResult()
            {
                SessionId = employee.Session.EmployeeSessionId,
                Token = employee.Session.Token
            };
        }
    }
}