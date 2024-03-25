using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate
{
    public interface IIncomingMessageRepository : IRepository<IncomingMessage>
    {
        IncomingMessage Add(IncomingMessage message);
        IncomingMessage Update(IncomingMessage message);
        Task<IncomingMessage> GetAsync(int Id);
        Task<IEnumerable<IncomingMessage>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
