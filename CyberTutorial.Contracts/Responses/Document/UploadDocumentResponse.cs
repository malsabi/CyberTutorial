namespace CyberTutorial.Contracts.Responses.Document
{
    public class UploadDocumentResponse
    {
        public int TotalUploadedFiles { get; set; }
        public long TotalUploadedFileSize { get; set; }
        public int TotalUpdatedFiles { get; set; }
        public long TotalUpdatedFileSize { get; set; }
    }
}