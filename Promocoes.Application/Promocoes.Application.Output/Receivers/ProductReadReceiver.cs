using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Output.Receivers
{
    public class ProductReadReceiver : IRequestHandler<ProductDTO, State>
    {
        private readonly IReadProductRepository _repository;

        public ProductReadReceiver(IReadProductRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(ProductDTO request, CancellationToken cancellationToken)
        {
            var GetProducts = _repository.GetAllProducts();

            return Task.FromResult(new State(200, "Produtos coletados com sucesso", GetProducts));
        }
    }
}