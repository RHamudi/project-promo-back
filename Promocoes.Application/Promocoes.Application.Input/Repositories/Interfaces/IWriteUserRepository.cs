using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Promocoes.Application.Input.Commands.UserContext;
using Promocoes.Domain.Entities;

namespace Promocoes.Application.Input.Repositories.Interfaces
{
    public interface IWriteUserRepository
    {
        void InsertUser(UserEntity user);
        void UpdateUser(UserEntity user);
        UserByIdDTO GetUserById(Guid user);
    }
}