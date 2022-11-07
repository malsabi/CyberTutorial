namespace CyberTutorial.Domain.Entities
{
    public class Document
    {
        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public long DocumentSize { get; set; }
        public string DocumentExtension { get; set; }
    }
}