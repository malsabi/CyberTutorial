using MediatR;
using ErrorOr;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Commands
{
    public class RegisterEmployeeCommand : IRequest<ErrorOr<RegisterResult>>
    {
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