using MediatR;
using Promocoes.Application.Input.Receivers;

namespace Promocoes.Application.Input.Commands.ProductContext
{
    public class ProductCommand : IRequest<State>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Images { get; private set; }
        public double Price { get; private set; }
        public string Duration { get; private set; }
    }
}