using ErrorOr;
using MediatR;
using CyberTutorial.Application.Documents.Common;

namespace CyberTutorial.Application.Documents.Queries.GetDocument
{
    public class GetDocumentByIdQuery : IRequest<ErrorOr<GetDocumentByIdResult>>
    {
        public string DocumentId { get; set; }
    }
}