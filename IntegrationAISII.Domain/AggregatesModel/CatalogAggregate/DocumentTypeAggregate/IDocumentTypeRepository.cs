using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>
    {
        DocumentType Add(DocumentType documentType);
        DocumentType Update(DocumentType documentType);
        Task<DocumentType> GetAsync(int Id);
        Task<IEnumerable<DocumentType>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
