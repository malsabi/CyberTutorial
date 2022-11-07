using FluentValidation;

namespace CyberTutorial.Application.Documents.Queries
{
    public class DownloadDocumentQueryValidator : AbstractValidator<DownloadDocumentQuery>
    {
        public DownloadDocumentQueryValidator()
        {
            RuleFor(x => x.DocumentId)
                .NotEmpty();
        }
    }
}