using MediatR;
using Promocoes.Application.Input.Commands.ProductContext;

namespace Promocoes.Application.Input.Receivers.ProductReceiver
{
    public class Insert : IRequestHandler<ProductCommand, State>
    {
        public Task<State> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}