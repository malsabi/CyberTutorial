namespace CyberTutorial.Application.Documents.Common
{
    public class DownloadDocumentResult
    {
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public byte[] DocumentData { get; set; }
    }
}