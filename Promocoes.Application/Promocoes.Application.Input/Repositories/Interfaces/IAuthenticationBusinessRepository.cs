using Promocoes.Application.Input.Commands.BusinessContext;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IAuthenticationBusinessRepository
    {
        void Authentication(AuthenticationCommand command);
    }
}