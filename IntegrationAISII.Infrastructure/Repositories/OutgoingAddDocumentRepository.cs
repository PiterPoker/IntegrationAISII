using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate;
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
    public class OutgoingAddDocumentRepository : IOutgoingAddDocumentRepository
    {
        private readonly IntegrationAISIIContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public OutgoingAddDocumentRepository(IntegrationAISIIContext context)
        {
            _context = context;
        }

        public OutgoingAddDocument Add(OutgoingAddDocument addDocument)
        {
            if (addDocument.IsTransient())
            {
                return _context.OutgoingAddDocuments
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
            var addDocument = await _context.OutgoingAddDocuments
                .SingleAsync(c => c.Id == Id);

            _context.OutgoingAddDocuments.Remove(addDocument);
        }

        public async Task<OutgoingAddDocument> Get(int Id)
        {
            var addDocument = await _context.OutgoingAddDocuments
                .SingleAsync(s => s.Id == Id);

            return addDocument;
        }

        public async Task<IEnumerable<OutgoingAddDocument>> GetAll(Expression<Func<OutgoingAddDocument, bool>>? predicate = default)
        {
            return await (predicate is not null ? _context.OutgoingAddDocuments
                .Where(predicate) : _context.OutgoingAddDocuments) 
                .ToListAsync();
        }

        public OutgoingAddDocument Update(OutgoingAddDocument addDocument)
        {
            return _context.OutgoingAddDocuments
                    .Update(addDocument)
                    .Entity;
        }
    }
}
