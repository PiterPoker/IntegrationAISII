using IntegrationAISII.Domain;
using IntegrationAISII.Domain.AggregatesModel.SubscriberAggregate;
using IntegrationAISII.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly IntegrationAISIIContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public SubscriberRepository(IntegrationAISIIContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Subscriber Add(Subscriber subscriber)
        {
            if (subscriber.IsTransient())
            {
                return _context.Subscribers
                    .Add(subscriber)
                    .Entity;
            }
            else
            {
                return subscriber;
            }
        }

        public async Task Delete(int Id)
        {
            var subscriber = await _context.Subscribers
                .SingleOrDefaultAsync(c => c.Id == Id);

            if (subscriber is null)
                throw new IntegrationAISIIDomainException($"Subcriber ID = {Id} is not found");

            _context.Subscribers.Remove(subscriber);
        }

        public async Task<IEnumerable<Subscriber>> GetAll(System.Linq.Expressions.Expression<Func<Subscriber, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.Subscribers
                .Where(predicate) : _context.Subscribers)
                .ToListAsync();
        }

        public async Task<Subscriber> Get(int Id)
        {
            var subscriber = await _context.Subscribers
                .SingleAsync(s => s.Id == Id);

            return subscriber;
        }

        public Subscriber Update(Subscriber subscriber)
        {
            return _context.Subscribers
                    .Update(subscriber)
                    .Entity;
        }
    }
}
