using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate;
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
    public class FileTypeRepository : IFileTypeRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public FileTypeRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public FileType Add(FileType fileType)
        {
            if (fileType.IsTransient())
            {
                return _context.FileTypes
                    .Add(fileType)
                    .Entity;
            }
            else
            {
                return fileType;
            }
        }

        public async Task Delete(int Id)
        {
            var fileType = await _context.FileTypes
                .SingleAsync(c => c.Id == Id);

            _context.FileTypes.Remove(fileType);
        }

        public async Task<FileType> Get(int Id)
        {
            var fileType = await _context.FileTypes
                .SingleAsync(s => s.Id == Id);

            return fileType;
        }

        public async Task<IEnumerable<FileType>> GetAll(Expression<Func<FileType, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.FileTypes
                .Where(predicate):
                _context.FileTypes)
                .ToListAsync();
        }

        public FileType Update(FileType fileType)
        {
            return _context.FileTypes
                    .Update(fileType)
                    .Entity;
        }
    }
}
