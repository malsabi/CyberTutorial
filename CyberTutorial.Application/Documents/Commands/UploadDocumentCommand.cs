using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using CyberTutorial.Application.Documents.Common;

namespace CyberTutorial.Application.Documents.Commands
{
    public class UploadDocumentCommand : IRequest<ErrorOr<UploadDocumentResult>>
    {
        public List<IFormFile> Documents { get; set; }
    }
}