using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OrganizationRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public Organization Add(Organization organization)
        {
            if (organization.IsTransient())
            {
                return _context.Organizations
                    .Add(organization)
                    .Entity;
            }
            else
            {
                return organization;
            }
        }

        public async Task Delete(int Id)
        {
            var organization = await _context.Organizations
                .SingleAsync(c => c.Id == Id);

            _context.Organizations.Remove(organization);
        }

        public async Task<Organization> Get(int Id)
        {
            var organization = await _context.Organizations
                .SingleAsync(s => s.Id == Id);

            return organization;
        }

        public async Task<IEnumerable<Organization>> GetAll(Expression<Func<Organization, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.Organizations
                .Where(predicate) : _context.Organizations)
                .ToListAsync();
        }

        public Organization Update(Organization organization)
        {
            return _context.Organizations
                    .Update(organization)
                    .Entity;
        }
    }
}
