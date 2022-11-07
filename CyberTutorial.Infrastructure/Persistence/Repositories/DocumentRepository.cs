using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public DocumentRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddDocumentAsync(Document document)
        {
            await applicationDbContext.Documents.AddAsync(document);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Document>> GetDocumentsAsync()
        {
            return await applicationDbContext.Documents.ToListAsync();
        }

        public async Task<Document> GetDocumentByIdAsync(string documentId)
        {
            return await applicationDbContext.Documents.FirstOrDefaultAsync(d => d.DocumentId == documentId);
        }

        public async Task<Document> GetDocumentByNameAsync(string documentName)
        {
            return await applicationDbContext.Documents.FirstOrDefaultAsync(d => d.DocumentName == documentName);
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            applicationDbContext.Documents.Update(document);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteDocumentAsync(string documentId)
        {
            Document document = await GetDocumentByIdAsync(documentId);
            applicationDbContext.Documents.Remove(document);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteDocumentAsync(Document document)
        {
            applicationDbContext.Documents.Remove(document);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}