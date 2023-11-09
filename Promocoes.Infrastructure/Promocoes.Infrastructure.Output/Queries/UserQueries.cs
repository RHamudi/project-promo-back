using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Application.Output.DTOs;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Output.Queries
{
    public class UserQueries : BaseQuery
    {
        public QueryModel GetAllUsers()
        {
            this.Table = Map.GetTableUser();

            this.Query = @$"
                        SELECT
                            tb.IdUser as IdUsuario,
                            tb.Name as Nome,
                            tb.Email as Email,
                            tb.Password as Senha,
                            tb.IdBusiness as IdEmpresa
                        FROM
                            {this.Table} tb
                        ";
            
            return new QueryModel(this.Query, null);
        }

        public QueryModel GetUserById(UserDTO command)
        {
            this.Table = Map.GetTableUser();

            this.Query = $@"
                        SELECT
                            tb.Name,
                            tb.Email,
                            tb.Password,
                            tb.IdBusiness 
                        FROM
                            tb_users tb WHERE IdUser = @IdUser
                        ";
            
            this.Parameters = new {
                IdUser = command.IdUsuario
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }

    
}