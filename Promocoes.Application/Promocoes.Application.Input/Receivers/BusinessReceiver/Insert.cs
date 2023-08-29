using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Receivers.Interfaces;

namespace Promocoes.Application.Input.Receivers.BusinessReceiver
{
    public class Insert : IReceiver<BusinessCommand, State>
    {
        public State Action(BusinessCommand command)
        {
            throw new NotImplementedException();
        }
    }
}