using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IDocumentRepository
    {
        Task AddDocumentAsync(Document document);
        Task<ICollection<Document>> GetDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(string documentId);
        Task<Document> GetDocumentByNameAsync(string documentName);
        Task UpdateDocumentAsync(Document document);
        Task DeleteDocumentAsync(string documentId);
        Task DeleteDocumentAsync(Document document);
    }
}