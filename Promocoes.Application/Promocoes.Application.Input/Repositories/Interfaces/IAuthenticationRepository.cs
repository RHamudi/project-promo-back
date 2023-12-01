using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Commands.UserContext;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        AuthenticationDTO Authentication(AuthenticationCommand command);
    }
}