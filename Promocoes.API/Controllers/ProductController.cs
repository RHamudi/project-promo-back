using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<IActionResult> InsertProduct([FromBody] ProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new ProductDTO()));
        }
    }
}