using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate
{
    public interface IOutgoingAddDocumentRepository : IRepository<OutgoingAddDocument>
    {
        OutgoingAddDocument Add(OutgoingAddDocument addDocument);
        OutgoingAddDocument Update(OutgoingAddDocument addDocument);
        Task<OutgoingAddDocument> Get(int Id);
        Task<IEnumerable<OutgoingAddDocument>> GetAll(Expression<Func<OutgoingAddDocument, bool>> predicate);
        Task Delete(int Id);
    }
}
