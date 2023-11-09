using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Promocoes.Application.Input.Commands.UserContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Application.Output.DTOs;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Receivers.UserReceiver
{
    public class Update : IRequestHandler<UpdateUserCommand, State>
    {
        private readonly IWriteUserRepository _repository;
        private readonly IMapper _mapper;

        public Update(IWriteUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<State> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userById = _repository.GetUserById(request.IdUser);

            if(userById == null)
                return Task.FromResult(new State(400, "Usuario não encontrado", request));
            
            var userUpdated = _mapper.Map(userById, request);

            return Task.FromResult(new State(200, "Update", userUpdated));
        }
    }
}