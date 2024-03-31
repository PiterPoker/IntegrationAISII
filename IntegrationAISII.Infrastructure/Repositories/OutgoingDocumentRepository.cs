using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate;
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
    public class OutgoingDocumentRepository : IOutgoingDocumentRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OutgoingDocumentRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public OutgoingDocument Add(OutgoingDocument document)
        {
            if (document.IsTransient())
            {
                return _context.OutgoingDocuments
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
            var document = await _context.OutgoingDocuments
                .SingleAsync(c => c.Id == Id);

            _context.OutgoingDocuments.Remove(document);
        }

        public async Task<OutgoingDocument> Get(int Id)
        {
            var document = await _context.OutgoingDocuments
                .SingleAsync(s => s.Id == Id);

            return document;
        }

        public async Task<IEnumerable<OutgoingDocument>> GetAll(Expression<Func<OutgoingDocument, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.OutgoingDocuments
                .Where(predicate) : _context.OutgoingDocuments) 
                .ToListAsync();
        }

        public OutgoingDocument Update(OutgoingDocument document)
        {
            return _context.OutgoingDocuments
                    .Update(document)
                    .Entity;
        }
    }
}
