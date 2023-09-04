using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;

namespace Promocoes.Application.Output.Receivers
{
    public class BusinessReadReceiver : IRequestHandler<BusinessDTO, State>
    {
        private readonly IReadBusinessRepository _repository;

        public BusinessReadReceiver(IReadBusinessRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(BusinessDTO request, CancellationToken cancellationToken)
        {
            var getBusiness = _repository.GetAllBusiness();

            return Task.FromResult(new State(200, "Empresas coletadas com sucesso", getBusiness));
        }
    }
}