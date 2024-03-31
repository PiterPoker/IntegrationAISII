using IntegrationAISII.Domain;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
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
    public class OutgoingMessageRepository : IOutgoingMessageRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OutgoingMessageRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public OutgoingMessage Add(OutgoingMessage message)
        {
            if (message.IsTransient())
            {
                return _context.OutgoingMessages
                    .Add(message)
                    .Entity;
            }
            else
            {
                return message;
            }
        }

        public async Task Delete(int Id)
        {
            var message = await _context.OutgoingMessages
                .SingleAsync(c => c.Id == Id);

            _context.OutgoingMessages.Remove(message);
        }

        public async Task<IEnumerable<OutgoingMessage>> GetAll(Expression<Func<OutgoingMessage, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.OutgoingMessages
                .Where(predicate) : _context.OutgoingMessages)
                .ToListAsync();
        }

        public async Task<OutgoingMessage> Get(int Id)
        {
            var message = await _context.OutgoingMessages
                .SingleAsync(s => s.Id == Id);

            return message;
        }

        public OutgoingMessage Update(OutgoingMessage message)
        {
            return _context.OutgoingMessages
                    .Update(message)
                    .Entity;
        }
    }
}
