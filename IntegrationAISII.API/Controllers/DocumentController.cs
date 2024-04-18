using IntegrationAISII.API.Application.Commands.Document.IncomingDocument;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAISII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DocumentController> _logger;
        public DocumentController(IMediator mediator,
            ILogger<DocumentController> logger) 
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task Get()
        {
            await _mediator.Send(new GetIncomingDocumentListCommand());
        } 
    }
}
