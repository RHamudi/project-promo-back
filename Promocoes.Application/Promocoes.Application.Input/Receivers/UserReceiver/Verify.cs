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
            throw new NotImplementedException();
        }
    }
}