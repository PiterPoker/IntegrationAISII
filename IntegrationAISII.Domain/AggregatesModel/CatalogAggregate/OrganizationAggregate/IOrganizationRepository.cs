using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Organization Add(Organization organization);
        Organization Update(Organization organization);
        Task<Organization> GetAsync(int Id);
        Task<IEnumerable<Organization>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
