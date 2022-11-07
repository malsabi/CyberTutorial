using FluentValidation;

namespace CyberTutorial.Application.Attempts.Queries.GetAttemptById
{
    public class GetAttemptByIdQueryValidator : AbstractValidator<GetAttemptByIdQuery>
    {
        public GetAttemptByIdQueryValidator()
        {
            RuleFor(x => x.AttemptId)
                .NotEmpty();
        }
    }
}