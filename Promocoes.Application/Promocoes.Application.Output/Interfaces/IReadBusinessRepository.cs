using ErrorOr;
using Promocoes.Application.Output.DTOs;

namespace Promocoes.Application.Output.Interfaces
{
    public interface IReadBusinessRepository
    {
        ErrorOr<IEnumerable<AllBusinessDTO>> GetAllBusiness();
        ErrorOr<AllBusinessDTO> GetBusinessById(Guid idEmpresa);
    }
}