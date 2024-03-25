using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate
{
    public interface IOutgoingMessageRepository : IRepository<OutgoingMessage>
    {
        OutgoingMessage Add(OutgoingMessage message);
        OutgoingMessage Update(OutgoingMessage message);
        Task<OutgoingMessage> GetAsync(int Id);
        Task<IEnumerable<OutgoingMessage>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
