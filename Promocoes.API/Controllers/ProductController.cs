using System.Security.Cryptography.X509Certificates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> InsertProduct([FromForm] ProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        
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