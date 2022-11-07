using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using CyberTutorial.Domain.Entities;
using Microsoft.AspNetCore.StaticFiles;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Documents.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Documents.Queries
{
    public class DownloadDocumentQueryHandler : IRequestHandler<DownloadDocumentQuery, ErrorOr<DownloadDocumentResult>>
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IWebHostEnvironment environment;

        public DownloadDocumentQueryHandler(IDocumentRepository documentRepository, IWebHostEnvironment environment)
        {
            this.documentRepository = documentRepository;
            this.environment = environment;
        }

        public async Task<ErrorOr<DownloadDocumentResult>> Handle(DownloadDocumentQuery request, CancellationToken cancellationToken)
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

            return new DownloadDocumentResult
            {
                DocumentName = document.DocumentName,
                DocumentType = contentType,
                DocumentData = fileBytes
            };
        }
    }
}