using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate
{
    public interface IOutgoingAddDocumentRepository : IRepository<OutgoingAddDocument>
    {
        OutgoingAddDocument Add(OutgoingAddDocument addDocument);
        OutgoingAddDocument Update(OutgoingAddDocument addDocument);
        Task<OutgoingAddDocument> GetAsync(int Id);
        Task<IEnumerable<OutgoingAddDocument>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
