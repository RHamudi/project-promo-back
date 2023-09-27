using MediatR;
using Microsoft.AspNetCore.Http;
using Promocoes.Application.Input.Receivers;

namespace Promocoes.Application.Input.Commands.ProductContext
{
    public class ProductCommand : IRequest<State>
    {
        public string IdBusiness { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Images { get; set; }
        public double Price { get; set; }

    }
}