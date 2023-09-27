using Promocoes.Application.Output.DTOs;

namespace Promocoes.Application.Output.Interfaces
{
    public interface IReadBusinessRepository
    {
        IEnumerable<AllBusinessDTO> GetAllBusiness();
        AllBusinessDTO GetBusinessById(Guid idEmpresa);
    }
}