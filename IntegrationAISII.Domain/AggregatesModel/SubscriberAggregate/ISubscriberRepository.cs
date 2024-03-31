using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.SubscriberAggregate
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        Subscriber Add(Subscriber subscriber);
        Subscriber Update(Subscriber subscriber);
        Task<Subscriber> Get(int Id);
        Task<IEnumerable<Subscriber>> GetAll(System.Linq.Expressions.Expression<Func<Subscriber, bool>> predicate);
        Task Delete(int Id);
    }
}
