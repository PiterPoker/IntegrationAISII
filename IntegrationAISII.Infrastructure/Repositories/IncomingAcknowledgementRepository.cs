using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate;
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
    public class IncomingAcknowledgementRepository : IIncomingAcknowledgementRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public IncomingAcknowledgementRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public IncomingAcknowledgement Add(IncomingAcknowledgement acknowledgement)
        {
            if (acknowledgement.IsTransient())
            {
                return _context.IncomingAcknowledgements
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
            var acknowledgement = await _context.IncomingAcknowledgements
                .SingleAsync(c => c.Id == Id);

            _context.IncomingAcknowledgements.Remove(acknowledgement);
        }

        public async Task<IncomingAcknowledgement> Get(int Id)
        {
            var acknowledgement = await _context.IncomingAcknowledgements
                .SingleAsync(s => s.Id == Id);

            return acknowledgement;
        }

        public async Task<IEnumerable<IncomingAcknowledgement>> GetAll(Expression<Func<IncomingAcknowledgement, bool>>? predicate = default)
        {
            return await (predicate is not null? _context.IncomingAcknowledgements
                .Where(predicate) : _context.IncomingAcknowledgements)
                .ToListAsync();
        }

        public IncomingAcknowledgement Update(IncomingAcknowledgement acknowledgement)
        {
            return _context.IncomingAcknowledgements
                    .Update(acknowledgement)
                    .Entity;
        }
    }
}
