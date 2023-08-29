using Promocoes.Application.Input.Commands.Interfaces;

namespace Promocoes.Application.Input.Receivers.Interfaces
{
    public interface IReceiver<in T, out W> where T : ICommand where W : State
    {
        W Action(T command);
    }
}