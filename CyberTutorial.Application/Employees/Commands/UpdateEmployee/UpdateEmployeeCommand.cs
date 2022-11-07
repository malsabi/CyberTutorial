using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<ErrorOr<UpdateEmployeeResult>>
    {
        public string TargetId { get; set; }
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}