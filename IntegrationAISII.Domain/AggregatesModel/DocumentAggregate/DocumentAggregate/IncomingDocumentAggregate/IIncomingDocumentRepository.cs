using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate
{
    public interface IIncomingDocumentRepository : IRepository<IncomingDocument>
    {
        IncomingDocument Add(IncomingDocument document);
        IncomingDocument Update(IncomingDocument document);
        Task<IncomingDocument> Get(int Id);
        Task<IEnumerable<IncomingDocument>> GetAll(Expression<Func<IncomingDocument, bool>> predicate);
        Task Delete(int Id);
    }
}
