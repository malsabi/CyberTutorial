using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Responses.Document;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class DocumentService : IDocumentService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }

        public DocumentService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<UploadDocumentResponse>> UploadDocumentAsync(List<IFormFile> documents)
        {
            return await clientApiService.PostAsync<List<IFormFile>, UploadDocumentResponse>(documents, ApiConsts.Document.Upload, Token);
        }

        public async Task<ErrorOr<string>> DownloadDocumentAsync(string documentId)
        {
            return await clientApiService.GetAsync<string>(ApiConsts.Document.Download, Token, documentId);
        }
    }
}