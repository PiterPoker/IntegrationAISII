using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate;
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
    public class OutgoingAcknowledgementRepository : IOutgoingAcknowledgementRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OutgoingAcknowledgementRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public OutgoingAcknowledgement Add(OutgoingAcknowledgement acknowledgement)
        {
            if (acknowledgement.IsTransient())
            {
                return _context.OutgoingAcknowledgements
                    .Add(acknowledgement)
                    .Entity;
            }
            else
            {
                return acknowledgement;
            }
        }

        public async Task Delete(int Id)
        {
            var acknowledgement = await _context.OutgoingAcknowledgements
                .SingleAsync(c => c.Id == Id);

            _context.OutgoingAcknowledgements.Remove(acknowledgement);
        }

        public async Task<OutgoingAcknowledgement> Get(int Id)
        {
            var acknowledgement = await _context.OutgoingAcknowledgements
                .SingleAsync(s => s.Id == Id);

            return acknowledgement;
        }

        public async Task<IEnumerable<OutgoingAcknowledgement>> GetAll(Expression<Func<OutgoingAcknowledgement, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.OutgoingAcknowledgements
                .Where(predicate) : _context.OutgoingAcknowledgements)
                .ToListAsync();
        }

        public OutgoingAcknowledgement Update(OutgoingAcknowledgement acknowledgement)
        {
            return _context.OutgoingAcknowledgements
                    .Update(acknowledgement)
                    .Entity;
        }
    }
}
