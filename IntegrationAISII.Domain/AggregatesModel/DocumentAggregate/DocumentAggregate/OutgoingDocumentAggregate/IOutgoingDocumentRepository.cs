using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate
{
    public interface IOutgoingDocumentRepository : IRepository<OutgoingDocument>
    {
        OutgoingDocument Add(OutgoingDocument document);
        OutgoingDocument Update(OutgoingDocument document);
        Task<OutgoingDocument> GetAsync(int Id);
        Task<IEnumerable<OutgoingDocument>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
