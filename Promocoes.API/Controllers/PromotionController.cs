using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promocoes.Application.Input.Commands.PromotionsContext;

namespace Promocoes.API.Controllers
{
    [ApiController]
    [Route("api/business/")]
    public class PromotionController : Controller
    {
        private readonly IMediator _mediator;
        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

       [HttpPost("")]
       public async Task<IActionResult> Insert([FromBody] PromotionsCommand promotion)
       {
            return Ok(await _mediator.Send(promotion));
       }
    }
}