using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.Dashboard
{
    public class EmployeeDashboardQuery : IRequest<ErrorOr<EmployeeDashboardResult>>
    {
        public string EmployeeId { get; set; }
    }
}