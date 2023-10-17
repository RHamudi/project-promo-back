
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.AspNetCore.OutputCaching;
using Promocoes.Application.Input.Commands.ProductContext;
using Promocoes.Application.Output.DTOs;

namespace Promocoes.API.Controllers
{
    [ApiController]
    [Route("api/product/")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertProduct([FromForm] ProductCommand command, IOutputCacheStore cache
        ,CancellationToken ct)
        {
            var result = await _mediator.Send(command);
            await cache.EvictByTagAsync("products", ct);
            return Ok(result);
        }

        [OutputCache(PolicyName = "ProductsRefresh")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new ProductDTO()));
        }

        [OutputCache(VaryByQueryKeys = new[] { "idEmpresa" })]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] string idEmpresa)
        {
            var result = await _mediator.Send(new ByIdProductDTO(idEmpresa));
            return Ok(result);
        }
    }
}