using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate
{
    public interface IFileTypeRepository : IRepository<FileType>
    {
        FileType Add(FileType fileType);
        FileType Update(FileType fileType);
        Task<FileType> GetAsync(int Id);
        Task<IEnumerable<FileType>> GetAllAsync();
        Task DeleteAsync(int Id);
    }
}
