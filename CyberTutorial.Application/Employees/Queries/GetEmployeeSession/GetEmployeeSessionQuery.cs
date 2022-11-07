using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeSession
{
    public class GetEmployeeSessionQuery : IRequest<ErrorOr<GetEmployeeSessionResult>>
    {
        public string EmployeeId { get; set; }
    }
}