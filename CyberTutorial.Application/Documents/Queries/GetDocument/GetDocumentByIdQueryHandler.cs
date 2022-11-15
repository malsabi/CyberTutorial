using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using CyberTutorial.Domain.Entities;
using Microsoft.AspNetCore.StaticFiles;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Documents.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Documents.Queries.GetDocument
{
    public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, ErrorOr<GetDocumentByIdResult>>
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IWebHostEnvironment environment;

        public GetDocumentByIdQueryHandler(IDocumentRepository documentRepository, IWebHostEnvironment environment)
        {
            this.documentRepository = documentRepository;
            this.environment = environment;
        }

        public async Task<ErrorOr<GetDocumentByIdResult>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();

            Document document = await documentRepository.GetDocumentByIdAsync(request.DocumentId);

            if (document == null)
            {
                return Errors.Document.DocumentNotFound;
            }

            string file = Path.Combine(environment.ContentRootPath, "Resources", "Documents", document.DocumentName);

            string contentType;
            if (!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }

            byte[] fileBytes;
            if (File.Exists(file))
            {
                fileBytes = await File.ReadAllBytesAsync(file);
            }
            else
            {
                return Errors.Document.DocumentFileNotFound;
            }

            return new GetDocumentByIdResult
            {
                DocumentData = fileBytes,
                DocumentType = contentType,
            };
        }
    }
}