using FluentValidation;

namespace CyberTutorial.Application.Documents.Commands
{
    public class UploadDocumentCommandValidator : AbstractValidator<UploadDocumentCommand>
    {
        public UploadDocumentCommandValidator()
        {
            RuleFor(x => x.Documents)
                .NotEmpty();
        }
    }
}