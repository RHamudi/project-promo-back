using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IWriteProductRepository
    {
        void InsertProduct(ProductEntity product);
    }
}