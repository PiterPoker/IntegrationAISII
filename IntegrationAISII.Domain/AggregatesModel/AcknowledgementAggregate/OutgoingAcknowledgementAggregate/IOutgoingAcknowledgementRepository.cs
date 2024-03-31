using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate
{
    public interface IOutgoingAcknowledgementRepository : IRepository<OutgoingAcknowledgement>
    {
        OutgoingAcknowledgement Add(OutgoingAcknowledgement acknowledgement);
        OutgoingAcknowledgement Update(OutgoingAcknowledgement acknowledgement);
        Task<OutgoingAcknowledgement> Get(int Id);
        Task<IEnumerable<OutgoingAcknowledgement>> GetAll(Expression<Func<OutgoingAcknowledgement, bool>> predicate);
        Task Delete(int Id);
    }
}
