using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using MapsterMapper;

namespace CyberTutorial.Application.Authentication.Commands.LoginEmployee
{
    public class LoginEmployeeCommandHandler : IRequestHandler<LoginEmployeeCommand, ErrorOr<LoginEmployeeResult>>
    {
        private readonly IMapper mapper;
        private readonly IHashProvider hashProvider;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IEmployeeRepository employeeRepository;

        public LoginEmployeeCommandHandler(IMapper mapper, IHashProvider hashProvider, IJwtTokenGenerator jwtTokenGenerator, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.hashProvider = hashProvider;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<LoginEmployeeResult>> Handle(LoginEmployeeCommand command, CancellationToken cancellationToken)
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
                return Errors.Authentication.OperationFailed;
            }

            employee.Session.ExpiryDate = DateTime.Now.AddDays(30).ToString();
            employee.Session.Token = jwtTokenGenerator.GenerateToken(employee);
            employee.Session.IsActive = true;

            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<LoginEmployeeResult>(employee.Session);
        }
    }
}