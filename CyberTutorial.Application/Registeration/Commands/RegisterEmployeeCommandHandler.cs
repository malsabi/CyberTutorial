using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using CyberTutorial.Application.Registeration.Common;

namespace CyberTutorial.Application.Registeration.Commands
{
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, ErrorOr<RegisterResult>>
    {
        private readonly IMapper mapper;
        private readonly IHashProvider hashProvider;
        private readonly ICompanyRepository companyRepository;
        private readonly IEmployeeRepository employeeRepository;

        public RegisterEmployeeCommandHandler(IMapper mapper, IHashProvider hashProvider, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.hashProvider = hashProvider;
            this.companyRepository = companyRepository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<RegisterResult>> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByIdAsync(request.CompanyId) == null)
            {
                return Errors.Company.NotFound;
            }
            else if (await companyRepository.GetCompanyByEmailAsync(request.EmailAddress) != null)
            {
                return Errors.Employee.DuplicateEmail;
            }

            if (await employeeRepository.GetEmployeeByEmailAsync(request.EmailAddress) != null)
            {
                return Errors.Employee.DuplicateEmail;
            }
            
            Employee employeeToRegister = mapper.Map<Employee>(request);

            employeeToRegister.Password = hashProvider.ApplyHash(employeeToRegister.Password);

            await employeeRepository.AddEmployeeAsync(employeeToRegister);

            return new RegisterResult
            {
                Id = string.Format("{0}-{1}", employeeToRegister.Id, employeeToRegister.CompanyId)
            };
        }
    }
}