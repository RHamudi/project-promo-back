using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Application.Input.Services.Jwt;

namespace Promocoes.Application.Input.Receivers.BusinessReceiver
{
    public class Authentication : IRequestHandler<AuthenticationCommand, State>
    {
        private readonly IAuthenticationRepository _repository;

        public Authentication(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var command = _repository.Authentication(request);
                if (command != null)
                {
                    var create = new CreateToken(request);
                    return Task.FromResult(new State(200, "Usuario autenticado com sucesso", new {
                        Authentication = create.Token,
                        User = command
                    }));
                }

                throw new Exception();

            }
            catch
            {
                return Task.FromResult(new State(400, "Credenciais incorretas", null));
            }
            
        }
    }
}