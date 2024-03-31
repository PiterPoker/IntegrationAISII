using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate
{
    public interface IIncomingAcknowledgementRepository : IRepository<IncomingAcknowledgement>
    {
        IncomingAcknowledgement Add(IncomingAcknowledgement acknowledgement);
        IncomingAcknowledgement Update(IncomingAcknowledgement acknowledgement);
        Task<IncomingAcknowledgement> Get(int Id);
        Task<IEnumerable<IncomingAcknowledgement>> GetAll(Expression<Func<IncomingAcknowledgement, bool>> predicate);
        Task Delete(int Id);
    }
}
