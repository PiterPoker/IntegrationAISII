using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate
{
    public interface IOutgoingDocumentRepository : IRepository<OutgoingDocument>
    {
        OutgoingDocument Add(OutgoingDocument document);
        OutgoingDocument Update(OutgoingDocument document);
        Task<OutgoingDocument> Get(int Id);
        Task<IEnumerable<OutgoingDocument>> GetAll(Expression<Func<OutgoingDocument, bool>> predicate);
        Task Delete(int Id);
    }
}
