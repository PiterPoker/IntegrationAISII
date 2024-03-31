using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate
{
    public interface IIncomingAddDocumentRepository : IRepository<IncomingAddDocument>
    {
        IncomingAddDocument Add(IncomingAddDocument addDocument);
        IncomingAddDocument Update(IncomingAddDocument addDocument);
        Task<IncomingAddDocument> Get(int Id);
        Task<IEnumerable<IncomingAddDocument>> GetAll(Expression<Func<IncomingAddDocument, bool>> predicate);
        Task Delete(int Id);
    }
}
