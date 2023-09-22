using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;

namespace Promocoes.Application.Output.Receivers
{
    public class AllBusinessReadReceiver : IRequestHandler<AllBusinessDTO, State>
    {
        private readonly IReadBusinessRepository _repository;

        public AllBusinessReadReceiver(IReadBusinessRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(AllBusinessDTO request, CancellationToken cancellationToken)
        {
            var getBusiness = _repository.GetAllBusiness();

            return Task.FromResult(new State(200, "Empresas coletadas com sucesso", getBusiness));
        }
    }
}