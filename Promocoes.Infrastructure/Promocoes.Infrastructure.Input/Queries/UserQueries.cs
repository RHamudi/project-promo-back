using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Input.Queries
{
    public class UserQueries : BaseQuery
    {
        public QueryModel InsertUser(UserEntity entity)
        {
            this.Table = Map.GetTableUser();

            this.Query = @$"
            INSERT INTO {this.Table}
            VALUES
            (
                @IdUser,
                @Name,
                @Email,
                @Password,
                @IdBusiness
            )
            ";

            this.Parameters = new {
                IdUser = entity.IdUser,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                IdBusiness = entity.IdBusiness
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}