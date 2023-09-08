using MediatR;
using Promocoes.Application.Input.Commands.ProductContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Receivers.ProductReceiver
{
    public class Insert : IRequestHandler<ProductCommand, State>
    {
        private readonly IWriteProductRepository _repository;

        public Insert(IWriteProductRepository repository)
        {
            _repository = repository;
        }

        public Task<State> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity(request.IdBusiness, request.Name, request.Description, request.Images, request.Price);

            if(!product.IsValid())
                return Task.FromResult(new State(400, "Não foi possivel adicionar o produto", product.Notifications));
            
            try
            {
                _repository.InsertProduct(product);
                return Task.FromResult(new State(200, "Produto adicionado com sucesso", product));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new State(400, "Não foi possivel adicionar o usuario", ex.Message));
            }
        }
    }
}