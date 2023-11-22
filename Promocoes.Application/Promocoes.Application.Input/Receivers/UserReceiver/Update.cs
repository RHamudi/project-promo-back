using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Promocoes.Application.Input.Commands.UserContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Receivers.UserReceiver
{
    public class Update : IRequestHandler<UpdateUserCommand, State>
    {
        private readonly IWriteUserRepository _repository;
        private readonly IReadUserRepository _readRepository;
        private readonly IMapper _mapper;

        public Update(IWriteUserRepository repository, IReadUserRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public Task<State> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userById = _readRepository.GetUserById(request.IdUser);

            if(userById == null)
                return Task.FromResult(new State(400, "Usuario não encontrado", request.IdUser));
            
            
            UpdateUserCommand userUpdated = new() {
                IdUser = request.IdUser,
                Name = request.Name != userById.Nome & request.Name != null ? request.Name :  userById.Nome, 
                Email = request.Email != userById.Email & request.Email != null ? request.Email : userById.Email,
                Password = request.Password != userById.Senha  & request.Password != null ? request.Password : userById.Senha,
                IdBusiness = request.IdBusiness != userById.IdEmpresa & request.IdBusiness != null ? request.IdBusiness : userById.IdEmpresa 
            };

            try
            {
                _repository.UpdateUser(userUpdated);
                return Task.FromResult(new State(200, "Usuario atualizado com sucesso", userUpdated));
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}