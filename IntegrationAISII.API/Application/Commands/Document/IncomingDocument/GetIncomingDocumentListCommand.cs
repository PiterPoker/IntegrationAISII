using IntegrationAISII.API.Application.Models.Document;
using MediatR;
using System.Runtime.Serialization;

namespace IntegrationAISII.API.Application.Commands.Document.IncomingDocument
{
    public class GetIncomingDocumentListCommand : IRequest<IncomingDocumentDTO>
    {

        public GetIncomingDocumentListCommand()
        {

        }
    }
}
