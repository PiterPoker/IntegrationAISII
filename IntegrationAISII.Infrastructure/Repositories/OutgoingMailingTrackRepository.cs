using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate;
using IntegrationAISII.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.Repositories
{
    public class OutgoingMailingTrackRepository : IOutgoingMailingTrackRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OutgoingMailingTrackRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public OutgoingMailingTrack Add(OutgoingMailingTrack mailingTrack)
        {
            if (mailingTrack.IsTransient())
            {
                return _context.OutgoingMailingTracks
                    .Add(mailingTrack)
                    .Entity;
            }
            else
            {
                return mailingTrack;
            }
        }

        public async Task Delete(int Id)
        {
            var mailingTrack = await _context.OutgoingMailingTracks
                .SingleAsync(c => c.Id == Id);

            _context.OutgoingMailingTracks.Remove(mailingTrack);
        }

        public async Task<IEnumerable<OutgoingMailingTrack>> GetAll(Expression<Func<OutgoingMailingTrack, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.OutgoingMailingTracks
                .Where(predicate) : _context.OutgoingMailingTracks)
                .ToListAsync();
        }

        public async Task<OutgoingMailingTrack> Get(int Id)
        {
            var mailingTrack = await _context.OutgoingMailingTracks
                .SingleAsync(s => s.Id == Id);

            return mailingTrack;
        }

        public OutgoingMailingTrack Update(OutgoingMailingTrack mailingTrack)
        {
            return _context.OutgoingMailingTracks
                    .Update(mailingTrack)
                    .Entity;
        }
    }
}
