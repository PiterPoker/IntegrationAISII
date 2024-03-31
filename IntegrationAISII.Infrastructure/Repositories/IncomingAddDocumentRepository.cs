using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate;
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
    public class IncomingAddDocumentRepository : IIncomingAddDocumentRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public IncomingAddDocumentRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public IncomingAddDocument Add(IncomingAddDocument addDocument)
        {
            if (addDocument.IsTransient())
            {
                return _context.IncomingAddDocuments
                    .Add(addDocument)
                    .Entity;
            }
            else
            {
                return addDocument;
            }
        }

        public async Task Delete(int Id)
        {
            var addDocument = await _context.IncomingAddDocuments
                .SingleAsync(c => c.Id == Id);

            _context.IncomingAddDocuments.Remove(addDocument);
        }

        public async Task<IncomingAddDocument> Get(int Id)
        {
            var addDocument = await _context.IncomingAddDocuments
                .SingleAsync(s => s.Id == Id);

            return addDocument;
        }

        public async Task<IEnumerable<IncomingAddDocument>> GetAll(Expression<Func<IncomingAddDocument, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.IncomingAddDocuments
                .Where(predicate):
                _context.IncomingAddDocuments)
                .ToListAsync();
        }

        public IncomingAddDocument Update(IncomingAddDocument addDocument)
        {
            return _context.IncomingAddDocuments
                    .Update(addDocument)
                    .Entity;
        }
    }
}
