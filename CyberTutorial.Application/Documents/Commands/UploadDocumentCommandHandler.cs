using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Documents.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Documents.Commands
{
    public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, ErrorOr<UploadDocumentResult>>
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IWebHostEnvironment environment;

        public UploadDocumentCommandHandler(IDocumentRepository documentRepository, IWebHostEnvironment environment)
        {
            this.documentRepository = documentRepository;
            this.environment = environment;
        }

        public async Task<ErrorOr<UploadDocumentResult>> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
        {
            int totalUploadedFiles = 0;
            long totalUploadedFileSize = 0;
            
            string rootPath = Path.Combine(environment.ContentRootPath, "Resources", "Documents");

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            foreach (IFormFile file in request.Documents)
            {
                if (await documentRepository.GetDocumentByNameAsync(file.FileName) is not null)
                {
                    continue;
                }

                string filePath = Path.Combine(rootPath, file.FileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Document document = new Document()
                    {
                        DocumentId = Guid.NewGuid().ToString(),
                        DocumentName = file.FileName,
                        DocumentType = file.ContentType,
                        DocumentSize = file.Length,
                        DocumentExtension = Path.GetExtension(file.FileName),
                    };
                    await file.CopyToAsync(fileStream);
                    await documentRepository.AddDocumentAsync(document);
                    totalUploadedFiles++;
                    totalUploadedFileSize += file.Length;
                }
            }
            return new UploadDocumentResult()
            {
                TotalUploadedFiles = totalUploadedFiles,
                TotalUploadedFileSize = totalUploadedFileSize
            };
        }
    }
}