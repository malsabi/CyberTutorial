using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeById
{
    public class GetEmployeeByIdQuery : IRequest<ErrorOr<GetEmployeeByIdResult>>
    {
        public string EmployeeId { get; set; }
    }
}