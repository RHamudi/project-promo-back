using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Input.Commands.UserContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Receivers.UserReceiver
{
    public class Insert : IRequestHandler<UserCommand, State>
    {
        private readonly IWriteUserRepository _repository;

        public Insert(IWriteUserRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity(request.Name, request.Email, request.Password, request.IdBusiness);

            if(!user.IsValid())
            {
                return Task.FromResult(new State(400, "Não foi possivel adicionar usuario", user.Notifications));
            }

            try
            {
                _repository.InsertUser(user);
                return Task.FromResult(new State(200, "Usuario inserido com sucesso", user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}