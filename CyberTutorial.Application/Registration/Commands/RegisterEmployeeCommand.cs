using MediatR;
using ErrorOr;
using CyberTutorial.Application.Registration.Common;

namespace CyberTutorial.Application.Registration.Commands
{
    public class RegisterEmployeeCommand : IRequest<ErrorOr<RegisterResult>>
    {
        public string Id { get; set; }
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