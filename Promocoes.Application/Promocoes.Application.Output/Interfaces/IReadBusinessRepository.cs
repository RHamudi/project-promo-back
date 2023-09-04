using Promocoes.Application.Output.DTOs;

namespace Promocoes.Application.Output.Interfaces
{
    public interface IReadBusinessRepository
    {
        IEnumerable<BusinessDTO> GetAllBusiness();
    }
}