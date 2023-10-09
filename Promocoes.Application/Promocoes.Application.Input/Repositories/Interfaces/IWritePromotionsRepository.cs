using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IWritePromotionsRepository
    {
        void InsertPromotions(PromotionsEntity promotions);
    }
}