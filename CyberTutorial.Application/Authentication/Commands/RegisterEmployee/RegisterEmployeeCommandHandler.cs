using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Common.Consts;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Employees.Commands.AddEmployee;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand, ErrorOr<RegisterEmployeeResult>>
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

        public async Task<ErrorOr<RegisterEmployeeResult>> Handle(RegisterEmployeeCommand command, CancellationToken cancellationToken)
        {
            AddEmployeeCommandHandler handler = new AddEmployeeCommandHandler(mapper, employeeRepository, companyRepository, hashProvider);
            ErrorOr<AddEmployeeResult> result = await handler.Handle(mapper.Map<AddEmployeeCommand>(command), cancellationToken);

            if (result.IsError)
            {
                return result.Errors;
            }
            else
            {
                string subject = Consts.Employee.VerificationSubject;
                string message = string.Format(Consts.Employee.VerificationCodeMessage, command.CompanyId);

                if (!await verificationProvider.SendCodeAsync(command.EmailAddress, subject, message))
                {
                    return Errors.Employee.OperationFailed;
                }
                return mapper.Map<RegisterEmployeeResult>(result.Value);
            }

            //if (await companyRepository.GetCompanyByIdAsync(request.CompanyId) is not Company company)
            //{
            //    return Errors.Company.NotFound;
            //}
            //else if (await companyRepository.GetCompanyByEmailAsync(request.EmailAddress) != null)
            //{
            //    return Errors.Employee.DuplicateEmail;
            //}
            //if (await employeeRepository.GetEmployeeByEmailAsync(request.EmailAddress) != null)
            //{
            //    return Errors.Employee.DuplicateEmail;
            //}

            //Employee employee = mapper.Map<Employee>(request);
            //employee.EmployeeId = Guid.NewGuid().ToString();
            //employee.Company = company;
            //employee.CompanyId = company.CompanyId;
            //employee.Password = hashProvider.ApplyHash(employee.Password);

            //employee.Session = new EmployeeSession()
            //{
            //    TimeCreated = DateTime.Now.ToString(),
            //    IsActive = false
            //};
            //employee.EmployeeDashboard = new EmployeeDashboard()
            //{
            //    TotalCourses = 0,
            //    TotalCoursesLastModified = DateTime.Now.ToString(),
            //    TotalQuizzes = 0,
            //    TotalQuizzesLastModified = DateTime.Now.ToString(),
            //    TotalPassed = 0,
            //    TotalPassedLastModified = DateTime.Now.ToString(),
            //    TotalFailed = 0,
            //    TotalFailedLastModified = DateTime.Now.ToString()
            //};
            //employee.TopEmployee = new TopEmployee()
            //{
            //    FirstName = employee.FirstName,
            //    LastName = employee.LastName,
            //    TotalQuizzes = 0,
            //    AverageScore = 0,
            //};

            //employee.Courses = new List<Course>();
            //employee.Attempts = new List<Attempt>();

            //string subject = Consts.Employee.VerificationSubject;
            //string message = string.Format(Consts.Employee.VerificationCodeMessage, request.CompanyId);

            //if (!await verificationProvider.SendCodeAsync(employee.EmailAddress, subject, message))
            //{
            //    return Errors.Employee.OperationFailed;
            //}

            //await employeeRepository.AddEmployeeAsync(employee);

            //return mapper.Map<RegisterEmployeeResult>(employee);
        }
    }
}