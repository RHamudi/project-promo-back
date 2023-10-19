using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Promocoes.Application.Input.Commands.PromotionsContext;
using Promocoes.Application.Output.DTOs;

namespace Promocoes.API.Controllers
{
    [ApiController]
    [Route("api/promotion/")]
    public class PromotionController : Controller
    {
        private readonly IMediator _mediator;
        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [OutputCache()]
        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] PromotionsCommand promotion, IOutputCacheStore cache
        ,CancellationToken ct)
        {
            await cache.EvictByTagAsync("Promotion", ct);
            return Ok(await _mediator.Send(promotion));
        }

        [OutputCache(PolicyName = "PromotionRefresh")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new PromotionDTO()));
        }
    }
}