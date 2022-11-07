using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using CyberTutorial.Contracts.Responses.Document;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IDocumentService
    {
        public string Token { get; set; }
        Task<ErrorOr<UploadDocumentResponse>> UploadDocumentAsync(List<IFormFile> documents);
        Task<ErrorOr<string>> DownloadDocumentAsync(string documentId);
    }
}