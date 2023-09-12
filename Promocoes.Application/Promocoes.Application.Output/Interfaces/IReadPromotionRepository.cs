using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Application.Output.DTOs;

namespace Promocoes.Application.Output.Interfaces
{
    public interface IReadPromotionRepository
    {
        IEnumerable<PromotionDTO> GetAllPromotions();
    }
}