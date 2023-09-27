using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;

namespace Promocoes.Application.Output.Receivers
{
    public class ByIdProductReadReceiver : IRequestHandler<ByIdProductDTO, State>
    {
        private readonly IReadProductRepository _repository;

        public ByIdProductReadReceiver(IReadProductRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(ByIdProductDTO request, CancellationToken cancellationToken)
        {
            var getProducts = _repository.GetProductsByBusinessId(request.IdEmpresa);

            return Task.FromResult(new State(200, "produdos coletados com sucesso", getProducts));
        }
    }
}