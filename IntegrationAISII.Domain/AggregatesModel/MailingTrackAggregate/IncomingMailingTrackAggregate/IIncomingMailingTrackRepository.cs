using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate
{
    public interface IIncomingMailingTrackRepository : IRepository<IncomingMailingTrack>
    {
        IncomingMailingTrack Add(IncomingMailingTrack mailingTrack);
        IncomingMailingTrack Update(IncomingMailingTrack mailingTrack);
        Task<IncomingMailingTrack> Get(int Id);
        Task<IEnumerable<IncomingMailingTrack>> GetAll(Expression<Func<IncomingMailingTrack, bool>> predicate);
        Task Delete(int Id);
    }
}
