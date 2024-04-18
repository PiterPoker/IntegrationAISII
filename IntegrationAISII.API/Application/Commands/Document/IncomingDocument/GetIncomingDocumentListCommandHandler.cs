using IntegrationAISII.API.Application.Models.Document;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using MediatR;

namespace IntegrationAISII.API.Application.Commands.Document.IncomingDocument
{
    public class GetIncomingDocumentListCommandHandler
        : IRequestHandler<GetIncomingDocumentListCommand, IncomingDocumentDTO>
    {
        private readonly IIncomingDocumentRepository _incomingDocumentRepository;

        public GetIncomingDocumentListCommandHandler(IIncomingDocumentRepository incomingDocumentRepository)
        {
            _incomingDocumentRepository = incomingDocumentRepository ?? throw new ArgumentNullException(nameof(incomingDocumentRepository));
        }

        public async Task<IncomingDocumentDTO> Handle(GetIncomingDocumentListCommand command, CancellationToken cancellationToken)
        {
            return default(IncomingDocumentDTO);
        }
    }
}
