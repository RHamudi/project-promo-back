using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Output.Queries
{
    public class BusinessQueries : BaseQuery
    {
        public QueryModel GetAllBusinessQuery()
        {
            this.Table = Map.GetTableBusiness();

            this.Query = $@"
            SELECT
	            tb.IdBusiness as IdEmpresa,
	            tb.Name as Nome,
	            tb.Description as Descricao,
	            tb.Logo as  LogoImagem,
	            tb.Location as Localizacao,
	            tb.Email as Email,
	            tb.Number as Numero,
	            tb.Site as Site,
	            tb.Category as Categoria,
	            tb.Operation as HorarioOperacao,
	            tb.Geodata as GeoLocalizacao,
	            tb.IsAdmin as Admin
            FROM
	            {this.Table} tb 
            ";

            return new QueryModel(this.Query, null);
        }
    }
}