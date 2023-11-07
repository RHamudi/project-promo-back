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
        public async Task<IActionResult> Insert([FromForm] BusinessCommand command, IOutputCacheStore cache
        ,CancellationToken ct)
        {
            var result = await _mediator.Send(command);
            await cache.EvictByTagAsync("Business", ct);
            return Ok(result);
        }
        
        [OutputCache(PolicyName = "Business")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBusiness()
        {
            var result = await _mediator.Send(new AllBusinessDTO());
            return Ok(result);
        }

        [OutputCache(VaryByQueryKeys = new[] { "idEmpresa" },PolicyName = "Business")]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] string idEmpresa)
        {
            var result = await _mediator.Send(new ByIdBusinessDTO(idEmpresa));
            return Ok(result);
        }

    }
}