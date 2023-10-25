using Promocoes.Application.Input.Commands.BusinessContext;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IAuthenticationBusinessRepository
    {
        AuthenticationCommand Authentication(AuthenticationCommand command);
    }
}