using Promocoes.Application.Input.Commands.ProductContext;
using Promocoes.Application.Input.Receivers.Interfaces;

namespace Promocoes.Application.Input.Receivers.ProductReceiver
{
    public class Insert : IReceiver<ProductCommand, State>
    {
        public State Action(ProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}