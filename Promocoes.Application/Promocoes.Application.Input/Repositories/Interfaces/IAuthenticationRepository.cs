using Promocoes.Application.Input.Commands.BusinessContext;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        AuthenticationCommand Authentication(AuthenticationCommand command);
    }
}