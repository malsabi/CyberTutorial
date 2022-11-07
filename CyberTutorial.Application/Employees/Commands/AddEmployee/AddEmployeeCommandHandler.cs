using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ErrorOr<AddEmployeeResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IHashProvider hashProvider;
        
        public AddEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IHashProvider hashProvider)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.companyRepository = companyRepository;
            this.hashProvider = hashProvider;
        }
        
        public async Task<ErrorOr<AddEmployeeResult>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
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

            Employee employee = mapper.Map<Employee>(request);

            employee.EmployeeId = Guid.NewGuid().ToString();
            employee.Company = company;
            employee.CompanyId = company.CompanyId;
            employee.Password = hashProvider.ApplyHash(employee.Password);
            
            employee.Session = new EmployeeSession()
            {
                TimeCreated = DateTime.Now.ToString(),
                IsActive = false
            };
            employee.EmployeeDashboard = new EmployeeDashboard()
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
            employee.TopEmployee = new TopEmployee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                TotalQuizzes = 0,
                AverageScore = 0,
            };
            
            employee.Courses = new List<Course>();
            employee.Attempts = new List<Attempt>();

            await employeeRepository.AddEmployeeAsync(employee);

            return mapper.Map<AddEmployeeResult>(employee);
        }
    }
}