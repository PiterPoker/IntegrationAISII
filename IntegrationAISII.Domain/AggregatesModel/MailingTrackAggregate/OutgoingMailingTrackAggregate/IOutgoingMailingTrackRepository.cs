using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate
{
    public interface IOutgoingMailingTrackRepository : IRepository<OutgoingMailingTrack>
    {
        OutgoingMailingTrack Add(OutgoingMailingTrack mailingTrack);
        OutgoingMailingTrack Update(OutgoingMailingTrack mailingTrack);
        Task<OutgoingMailingTrack> Get(int Id);
        Task<IEnumerable<OutgoingMailingTrack>> GetAll(Expression<Func<OutgoingMailingTrack, bool>> predicate);
        Task Delete(int Id);
    }
}
