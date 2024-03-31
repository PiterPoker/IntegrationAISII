using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate
{
    public interface IOutgoingMessageRepository : IRepository<OutgoingMessage>
    {
        OutgoingMessage Add(OutgoingMessage message);
        OutgoingMessage Update(OutgoingMessage message);
        Task<OutgoingMessage> Get(int Id);
        Task<IEnumerable<OutgoingMessage>> GetAll(Expression<Func<OutgoingMessage, bool>> predicate);
        Task Delete(int Id);
    }
}
