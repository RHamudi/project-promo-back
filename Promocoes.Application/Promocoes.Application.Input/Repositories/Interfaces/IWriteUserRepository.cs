using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IWriteUserRepository
    {
        void InsertUser(UserEntity user);
    }
}