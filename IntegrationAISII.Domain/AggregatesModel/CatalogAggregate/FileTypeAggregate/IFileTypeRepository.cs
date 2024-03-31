using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate
{
    public interface IFileTypeRepository : IRepository<FileType>
    {
        FileType Add(FileType fileType);
        FileType Update(FileType fileType);
        Task<FileType> Get(int Id);
        Task<IEnumerable<FileType>> GetAll(Expression<Func<FileType, bool>> predicate);
        Task Delete(int Id);
    }
}
