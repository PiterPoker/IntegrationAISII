using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
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
    public class IncomingDocumentRepository : IIncomingDocumentRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public IncomingDocumentRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public IncomingDocument Add(IncomingDocument document)
        {
            if (document.IsTransient())
            {
                return _context.IncomingDocuments
                    .Add(document)
                    .Entity;
            }
            else
            {
                return document;
            }
        }

        public async Task Delete(int Id)
        {
            var document = await _context.IncomingDocuments
                .SingleAsync(c => c.Id == Id);

            _context.IncomingDocuments.Remove(document);
        }

        public async Task<IncomingDocument> Get(int Id)
        {
            var document = await _context.IncomingDocuments
                .SingleAsync(s => s.Id == Id);

            return document;
        }

        public async Task<IEnumerable<IncomingDocument>> GetAll(Expression<Func<IncomingDocument, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.IncomingDocuments
                .Where(predicate): _context.IncomingDocuments)
                .ToListAsync();
        }

        public IncomingDocument Update(IncomingDocument document)
        {
            return _context.IncomingDocuments
                    .Update(document)
                    .Entity;
        }
    }
}
