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

        public QueryModel GetUserById(Guid command)
        {
            this.Table = Map.GetTableUser();

            this.Query = $@"
                        SELECT
                            tb.IdUser as IdUsuario,
                            tb.Name as Nome,
                            tb.Email as Email,
                            tb.Password as Senha,
                            tb.IdBusiness as IdEmpresa
                        FROM
                            {this.Table} tb WHERE IdUser = '{command}'
                        ";
            
            this.Parameters = new {
                IdUser = command
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }

    
}