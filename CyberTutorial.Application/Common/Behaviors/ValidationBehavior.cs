using MediatR;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;

namespace CyberTutorial.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            this.validator = validator;
        }
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validator is not null)
            {
                ValidationResult validationResult = await validator.ValidateAsync(request);

                List<Error> errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

                if (errors.Any())
                {
                    return (dynamic)errors;
                }
            }
            return await next();
        }
    }
}