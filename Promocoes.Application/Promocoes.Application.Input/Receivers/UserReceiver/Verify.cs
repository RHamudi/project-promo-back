using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Input.Commands.UserContext;
using Promocoes.Application.Input.Repositories.Interfaces;

namespace Promocoes.Application.Input.Receivers.UserReceiver
{
    public class Verify : IRequestHandler<VerificationCommand, State>
    {
        private readonly IWriteUserRepository _repository;

        public Verify(IWriteUserRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(VerificationCommand request, CancellationToken cancellationToken)
        {
            var verifyToken = _repository.VerifyUser(request);

            if(!verifyToken)
            {
                return Task.FromResult(new State(400, "Token Invalido", null));
            }

            try
            {
                _repository.UpdateUserDate(DateTime.Now, request.Token);
                return Task.FromResult(new State(200, "User Verificado!", null));
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}