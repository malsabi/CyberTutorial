using FluentValidation;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(command => command.EmployeeId)
                .NotEmpty();

            RuleFor(command => command.TargetId)
               .NotEmpty();

            RuleFor(command => command.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(command => command.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(command => command.Gender)
                .NotEmpty();

            RuleFor(command => command.DateOfBirth)
                .NotEmpty();

            RuleFor(command => command.PhoneNumber)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(10);

            RuleFor(command => command.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(command => command.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(65);
        }
    }
}