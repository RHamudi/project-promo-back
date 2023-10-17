using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Services.Jwt;
using Promocoes.Application.Output.DTOs;

namespace Promocoes.API.Controllers
{
    [ApiController]
    [Route("api/business/")]
    public class BusinessController : Controller
    {
        private readonly IMediator _mediator;

        public BusinessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromForm] BusinessCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBusiness()
        {
            var result = await _mediator.Send(new AllBusinessDTO());
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] string idEmpresa)
        {
            var result = await _mediator.Send(new ByIdBusinessDTO(idEmpresa));
            return Ok(result);
        }

        [HttpPost("Authentication")]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationCommand model)
        {
            var result = await _mediator.Send(new AuthenticationCommand(model.Email, model.Password));
            return Ok(result);
        }
    }
}