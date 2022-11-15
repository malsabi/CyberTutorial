using FluentValidation;

namespace CyberTutorial.Application.Documents.Queries.DownloadDocument
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