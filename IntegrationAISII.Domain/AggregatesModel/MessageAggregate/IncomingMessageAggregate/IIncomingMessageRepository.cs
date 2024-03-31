using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate
{
    public interface IIncomingMessageRepository : IRepository<IncomingMessage>
    {
        IncomingMessage Add(IncomingMessage message);
        IncomingMessage Update(IncomingMessage message);
        Task<IncomingMessage> Get(int Id);
        Task<IEnumerable<IncomingMessage>> GetAll(Expression<Func<IncomingMessage, bool>> predicate);
        Task Delete(int Id);
    }
}
