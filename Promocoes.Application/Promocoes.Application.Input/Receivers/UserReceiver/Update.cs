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
                return Task.FromResult(new State(400, "Usuario não encontrado", request.IdUser));
            
            UpdateUserCommand userUpdated = new() {
                IdUser = request.IdUser,
                Name = userById.Name != request.Name ? request.Name : userById.Name,
                Email = userById.Email != request.Email ? request.Email : userById.Email,
                Password = userById.Password != request.Password ? request.Password : userById.Password,
                IdBusiness = userById.IdBusiness != request.IdBusiness ? request.IdBusiness : userById.IdBusiness 
            };

            try
            {
                //_repository.UpdateUser(userUpdated);
                return Task.FromResult(new State(200, "Usuario atualizado com sucesso", userUpdated));
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}