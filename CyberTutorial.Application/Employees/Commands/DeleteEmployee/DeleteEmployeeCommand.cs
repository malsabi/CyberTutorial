using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<ErrorOr<DeleteEmployeeResult>>
    {
        public string EmployeeId { get; set; }
    }
}