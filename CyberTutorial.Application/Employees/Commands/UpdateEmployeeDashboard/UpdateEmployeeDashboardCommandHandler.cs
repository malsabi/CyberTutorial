using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployeeDashboard
{
    public class UpdateEmployeeDashboardCommandHandler : IRequestHandler<UpdateEmployeeDashboardCommand, ErrorOr<UpdateEmployeeDashboardResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
    
        public UpdateEmployeeDashboardCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<UpdateEmployeeDashboardResult>> Handle(UpdateEmployeeDashboardCommand request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeDashboardId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            if (employee.EmployeeDashboard is null)
            {
                return Errors.Employee.NoDashboardFound;
            }

            employee.EmployeeDashboard.TotalCourses = request.TotalCourses;
            employee.EmployeeDashboard.TotalCoursesLastModified = request.TotalCoursesLastModified;
            employee.EmployeeDashboard.TotalQuizzes = request.TotalQuizzes;
            employee.EmployeeDashboard.TotalQuizzesLastModified = request.TotalQuizzesLastModified;
            employee.EmployeeDashboard.TotalPassed = request.TotalPassed;
            employee.EmployeeDashboard.TotalPassedLastModified = request.TotalPassedLastModified;
            employee.EmployeeDashboard.TotalFailed = request.TotalFailed;
            employee.EmployeeDashboard.TotalFailedLastModified = request.TotalFailedLastModified;

            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<UpdateEmployeeDashboardResult>(employee.EmployeeDashboard);
        }
    }
}