using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate
{
    public interface IIncomingMailingTrackRepository : IRepository<IncomingMailingTrack>
    {
        IncomingMailingTrack Add(IncomingMailingTrack mailingTrack);
        IncomingMailingTrack Update(IncomingMailingTrack mailingTrack);
        Task<IncomingMailingTrack> GetAsync(int Id);
        Task<IEnumerable<IncomingMailingTrack>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
