using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Domain.Validations.Interfaces
{
    public interface IValidate
    {
        bool IsValid();
    }
}