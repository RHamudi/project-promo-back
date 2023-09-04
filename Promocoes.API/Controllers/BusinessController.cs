using MediatR;
using Microsoft.AspNetCore.Mvc;
using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Receivers.BusinessReceiver;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Application.Output.DTOs;

namespace Promocoes.API.Controllers
{
    [ApiController]
    [Route("api/business/")]
    public class BusinessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] BusinessCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusiness()
        {
            
            var result = await _mediator.Send(new BusinessDTO());
            return Ok(result);
        }
    }
}