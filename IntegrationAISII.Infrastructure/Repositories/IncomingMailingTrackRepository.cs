using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate;
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
    public class IncomingMailingTrackRepository : IIncomingMailingTrackRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public IncomingMailingTrackRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public IncomingMailingTrack Add(IncomingMailingTrack mailingTrack)
        {
            if (mailingTrack.IsTransient())
            {
                return _context.IncomingMailingTracks
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
            var mailingTrack = await _context.IncomingMailingTracks
                .SingleAsync(c => c.Id == Id);

            _context.IncomingMailingTracks.Remove(mailingTrack);
        }

        public async Task<IncomingMailingTrack> Get(int Id)
        {
            var mailingTrack = await _context.IncomingMailingTracks
                .SingleAsync(s => s.Id == Id);

            return mailingTrack;
        }

        public async Task<IEnumerable<IncomingMailingTrack>> GetAll(Expression<Func<IncomingMailingTrack, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.IncomingMailingTracks
                .Where(predicate) : _context.IncomingMailingTracks)
                .ToListAsync();
        }

        public IncomingMailingTrack Update(IncomingMailingTrack mailingTrack)
        {
            return _context.IncomingMailingTracks
                    .Update(mailingTrack)
                    .Entity;
        }
    }
}
