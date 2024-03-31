using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
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
    public class IncomingMessageRepository : IIncomingMessageRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public IncomingMessageRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public IncomingMessage Add(IncomingMessage message)
        {
            if (message.IsTransient())
            {
                return _context.IncomingMessages
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
            var message = await _context.IncomingMessages
                .SingleAsync(c => c.Id == Id);

            _context.IncomingMessages.Remove(message);
        }

        public async Task<IncomingMessage> Get(int Id)
        {
            var message = await _context.IncomingMessages
                .SingleAsync(s => s.Id == Id);

            return message;
        }

        public async Task<IEnumerable<IncomingMessage>> GetAll(Expression<Func<IncomingMessage, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.IncomingMessages
                .Where(predicate) :
            _context.IncomingMessages)
                .ToListAsync();
        }

        public IncomingMessage Update(IncomingMessage message)
        {
            return _context.IncomingMessages
                    .Update(message)
                    .Entity;
        }
    }
}
