using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate
{
    public interface IIncomingAddDocumentRepository : IRepository<IncomingAddDocument>
    {
        IncomingAddDocument Add(IncomingAddDocument addDocument);
        IncomingAddDocument Update(IncomingAddDocument addDocument);
        Task<IncomingAddDocument> GetAsync(int Id);
        Task<IEnumerable<IncomingAddDocument>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
