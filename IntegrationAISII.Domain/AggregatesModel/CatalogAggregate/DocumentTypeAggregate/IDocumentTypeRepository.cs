using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>
    {
        DocumentType Add(DocumentType documentType);
        DocumentType Update(DocumentType documentType);
        Task<DocumentType> Get(int Id);
        Task<IEnumerable<DocumentType>> GetAll(Expression<Func<DocumentType, bool>> predicate);
        Task Delete(int Id);
    }
}
