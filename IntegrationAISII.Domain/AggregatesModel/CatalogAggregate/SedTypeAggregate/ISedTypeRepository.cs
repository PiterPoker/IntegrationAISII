using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate
{
    public interface ISedTypeRepository : IRepository<SedType>
    {
        SedType Add(SedType sedType);
        SedType Update(SedType sedType);
        Task<SedType> Get(int Id);
        Task<IEnumerable<SedType>> GetAll(Expression<Func<SedType, bool>> predicate);
        Task Delete(int Id);
    }
}
