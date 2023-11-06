using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            
            return new QueryModel(this.Table, null);
        }
    }
}