namespace CyberTutorial.Application.Documents.Common
{
    public class UploadDocumentResult
    {
        public int TotalUploadedFiles { get; set; }
        public long TotalUploadedFileSize { get; set; }
        public int TotalUpdatedFiles { get; set; }
        public long TotalUpdatedFileSize { get; set; }
    }
}