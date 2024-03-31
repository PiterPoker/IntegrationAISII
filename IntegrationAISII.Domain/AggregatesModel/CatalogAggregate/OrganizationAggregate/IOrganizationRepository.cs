using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Organization Add(Organization organization);
        Organization Update(Organization organization);
        Task<Organization> Get(int Id);
        Task<IEnumerable<Organization>> GetAll(Expression<Func<Organization, bool>> predicate);
        Task Delete(int Id);
    }
}
