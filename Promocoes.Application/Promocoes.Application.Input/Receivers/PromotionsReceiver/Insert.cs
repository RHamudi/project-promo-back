using MediatR;
using Promocoes.Application.Input.Commands.PromotionsContext;

namespace Promocoes.Application.Input.Receivers.PromotionsReceiver
{
    public class Insert : IRequestHandler<PromotionsCommand, State>
    {
        public Task<State> Handle(PromotionsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}