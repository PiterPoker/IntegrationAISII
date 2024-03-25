using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate
{
    public interface IIncomingAcknowledgementRepository : IRepository<IncomingAcknowledgement>
    {
        IncomingAcknowledgement Add(IncomingAcknowledgement acknowledgement);
        IncomingAcknowledgement Update(IncomingAcknowledgement acknowledgement);
        Task<IncomingAcknowledgement> GetAsync(int Id);
        Task<IEnumerable<IncomingAcknowledgement>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
