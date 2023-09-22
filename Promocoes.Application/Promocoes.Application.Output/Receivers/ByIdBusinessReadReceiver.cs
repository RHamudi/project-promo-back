using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;

namespace Promocoes.Application.Output.Receivers
{
    public class ByIdBusinessReadReceiver : IRequestHandler<ByIdBusinessDTO, State>
    {
        private readonly IReadBusinessRepository _repository;

        public ByIdBusinessReadReceiver(IReadBusinessRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(ByIdBusinessDTO request, CancellationToken cancellationToken)
        {
            var getBusiness = _repository.GetBusinessById(request.IdEmpresa);

            return Task.FromResult(new State(200, "Empresa coletada com sucesso", getBusiness));
        }
    }
}