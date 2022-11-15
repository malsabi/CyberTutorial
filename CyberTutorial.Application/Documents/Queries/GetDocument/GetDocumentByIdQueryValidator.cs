using FluentValidation;

namespace CyberTutorial.Application.Documents.Queries.GetDocument
{
    public class GetDocumentByIdQueryValidator : AbstractValidator<GetDocumentByIdQuery>
    {
        public GetDocumentByIdQueryValidator()
        {
            RuleFor(x => x.DocumentId)
                .NotEmpty();
        }
    }
}