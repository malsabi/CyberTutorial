using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployeeSession
{
    public class UpdateEmployeeSessionCommand : IRequest<ErrorOr<UpdateEmployeeSessionResult>>
    {
        public string TargetId { get; set; }
        public string EmployeeSessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}