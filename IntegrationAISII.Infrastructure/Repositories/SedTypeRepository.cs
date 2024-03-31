using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate;
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
    public class SedTypeRepository : ISedTypeRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public SedTypeRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public SedType Add(SedType sedType)
        {
            if (sedType.IsTransient())
            {
                return _context.SedTypes
                    .Add(sedType)
                    .Entity;
            }
            else
            {
                return sedType;
            }
        }

        public async Task Delete(int Id)
        {
            var sedType = await _context.SedTypes
                .SingleAsync(c => c.Id == Id);

            _context.SedTypes.Remove(sedType);
        }

        public async Task<SedType> Get(int Id)
        {
            var sedType = await _context.SedTypes
                .SingleAsync(s => s.Id == Id);

            return sedType;
        }

        public async Task<IEnumerable<SedType>> GetAll(Expression<Func<SedType, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.SedTypes
                .Where(predicate) : _context.SedTypes)
                .ToListAsync();
        }

        public SedType Update(SedType sedType)
        {
            return _context.SedTypes
                    .Update(sedType)
                    .Entity;
        }
    }
}
