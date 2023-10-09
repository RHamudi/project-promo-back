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
        private readonly IAuthenticationBusinessRepository _repository;

        public Authentication(IAuthenticationBusinessRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Authentication(request);
                var create = new CreateToken(request);
                return Task.FromResult(new State(200, "Usuario autenticado com sucesso", create.Token));
            }
            catch
            {
                return Task.FromResult(new State(200, "Credenciais incorretas", null));
            }
            
        }
    }
}