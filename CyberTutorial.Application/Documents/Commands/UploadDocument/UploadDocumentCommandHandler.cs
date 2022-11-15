using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Documents.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Documents.Commands.UploadDocument
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
            int totalUpdatedFiles = 0;
            long totalUpdatedFileSize = 0;

            string rootPath = Path.Combine(environment.ContentRootPath, "Resources", "Documents");

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            foreach (IFormFile file in request.Documents)
            {
                string filePath = Path.Combine(rootPath, file.FileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    if (await documentRepository.GetDocumentByNameAsync(file.FileName) is Document document)
                    {
                        document.DocumentType = file.ContentType;
                        document.DocumentSize = file.Length;
                        document.DocumentExtension = Path.GetExtension(file.FileName);
                        await documentRepository.UpdateDocumentAsync(document);
                        totalUpdatedFiles++;
                        totalUpdatedFileSize += file.Length;
                    }
                    else
                    {
                        Document documentToAdd = new Document()
                        {
                            DocumentId = Guid.NewGuid().ToString(),
                            DocumentName = file.FileName,
                            DocumentType = file.ContentType,
                            DocumentSize = file.Length,
                            DocumentExtension = Path.GetExtension(file.FileName),
                        };
                        await documentRepository.AddDocumentAsync(documentToAdd);
                        totalUploadedFiles++;
                        totalUploadedFileSize += file.Length;
                    }
                    await file.CopyToAsync(fileStream, cancellationToken);
                }
            }
            return new UploadDocumentResult()
            {
                TotalUploadedFiles = totalUploadedFiles,
                TotalUploadedFileSize = totalUploadedFileSize,
                TotalUpdatedFiles = totalUpdatedFiles,
                TotalUpdatedFileSize = totalUpdatedFileSize
            };
        }
    }
}