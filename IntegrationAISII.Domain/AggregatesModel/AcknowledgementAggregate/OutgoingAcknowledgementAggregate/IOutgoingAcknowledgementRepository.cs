using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate
{
    public interface IOutgoingAcknowledgementRepository : IRepository<OutgoingAcknowledgement>
    {
        OutgoingAcknowledgement Add(OutgoingAcknowledgement acknowledgement);
        OutgoingAcknowledgement Update(OutgoingAcknowledgement acknowledgement);
        Task<OutgoingAcknowledgement> GetAsync(int Id);
        Task<IEnumerable<OutgoingAcknowledgement>> GetAllAsync();
        Task DeleteAsync(int acknowledgementId);
    }
}
