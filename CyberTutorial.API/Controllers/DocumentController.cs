using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Responses.Document;
using CyberTutorial.Application.Documents.Common;
using CyberTutorial.Application.Documents.Queries;
using CyberTutorial.Application.Documents.Commands;

namespace CyberTutorial.API.Controllers
{

    [Route("api/[controller]")]
    [AllowAnonymous]
    public class DocumentController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public DocumentController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(List<IFormFile> documents)
        {
            UploadDocumentCommand command = new UploadDocumentCommand()
            {
                Documents = documents
            };
            ErrorOr<UploadDocumentResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UploadDocumentResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("Download")]
        public async Task<IActionResult> Download(string documentId)
        {
            DownloadDocumentQuery query = new DownloadDocumentQuery()
            {
                DocumentId = documentId
            };
            ErrorOr<DownloadDocumentResult> result = await sender.Send(query);
            return result.Match
            (
                success => File(success.DocumentData, success.DocumentType, success.DocumentName),
                error => Problem(error)
            );
        }
    }
}