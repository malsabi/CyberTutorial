using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Consts;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Commands
{
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, ErrorOr<RegisterResult>>
    {
        private readonly IMapper mapper;
        private readonly IHashProvider hashProvider;
        private readonly ICompanyRepository companyRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IVerificationProvider verificationProvider;

        public RegisterEmployeeCommandHandler(IMapper mapper, IHashProvider hashProvider, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IVerificationProvider verificationProvider)
        {
            this.mapper = mapper;
            this.hashProvider = hashProvider;
            this.companyRepository = companyRepository;
            this.employeeRepository = employeeRepository;
            this.verificationProvider = verificationProvider;
        }
        
        public async Task<ErrorOr<RegisterResult>> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByIdAsync(request.CompanyId) is not Company company)
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

            employeeToRegister.Company = company;
            employeeToRegister.Password = hashProvider.ApplyHash(employeeToRegister.Password);

            employeeToRegister.Session = new EmployeeSession()
            {
                TimeCreated = DateTime.Now.ToString(),
                IsActive = false
            };

            employeeToRegister.EmployeeDashboard = new EmployeeDashboard()
            {
                TotalCourses = 0,
                TotalCoursesLastModified = DateTime.Now.ToString(),
                TotalQuizzes = 0,
                TotalQuizzesLastModified = DateTime.Now.ToString(),
                TotalPassed = 0,
                TotalPassedLastModified = DateTime.Now.ToString(),
                TotalFailed = 0,
                TotalFailedLastModified = DateTime.Now.ToString()
            };

            string subject = Consts.Employee.VerificationSubject;
            string message = string.Format(Consts.Employee.VerificationCodeMessage, request.CompanyId);

            if (!await verificationProvider.SendCodeAsync(employeeToRegister.EmailAddress, subject, message))
            {
                return Errors.Employee.OperationFailed;
            }

            await employeeRepository.AddEmployeeAsync(employeeToRegister);

            return new RegisterResult
            {
                EmployeeId = employeeToRegister.EmployeeId
            };
        }
    }
}