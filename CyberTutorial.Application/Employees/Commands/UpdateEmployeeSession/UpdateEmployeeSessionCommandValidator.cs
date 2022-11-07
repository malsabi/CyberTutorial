using FluentValidation;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployeeSession
{
    public class UpdateEmployeeSessionCommandValidator : AbstractValidator<UpdateEmployeeSessionCommand>
    {
        public UpdateEmployeeSessionCommandValidator()
        {
            RuleFor(x => x.TargetId)
              .NotEmpty();

            RuleFor(x => x.EmployeeSessionId)
                .NotEmpty();

            RuleFor(x => x.TimeCreated)
                .NotEmpty();

            RuleFor(x => x.ExpiryDate)
                .NotEmpty();

            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}