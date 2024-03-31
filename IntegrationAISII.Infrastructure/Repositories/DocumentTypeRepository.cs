using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
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
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public DocumentTypeRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public DocumentType Add(DocumentType documentType)
        {
            if (documentType.IsTransient())
            {
                return _context.DocumentTypes
                    .Add(documentType)
                    .Entity;
            }
            else
            {
                return documentType;
            }
        }

        public async Task Delete(int Id)
        {
            var documentType = await _context.DocumentTypes
                .SingleAsync(c => c.Id == Id);

            _context.DocumentTypes.Remove(documentType);
        }

        public async Task<DocumentType> Get(int Id)
        {
            var documentType = await _context.DocumentTypes
                .SingleAsync(s => s.Id == Id);

            return documentType;
        }

        public async Task<IEnumerable<DocumentType>> GetAll(Expression<Func<DocumentType, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.DocumentTypes
                .Where(predicate) : 
                _context.DocumentTypes) 
                .ToListAsync();
        }

        public DocumentType Update(DocumentType documentType)
        {
            return _context.DocumentTypes
                    .Update(documentType)
                    .Entity;
        }
    }
}
