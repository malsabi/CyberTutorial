using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeDashboard
{
    public class GetEmployeeDashboardQuery : IRequest<ErrorOr<GetEmployeeDashboardResult>>
    {
        public string EmployeeId { get; set; }
    }
}