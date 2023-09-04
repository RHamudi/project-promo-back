using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IWriteBusinessRepository
    {
        void InsertBusiness(BusinessEntity business);
    }
}