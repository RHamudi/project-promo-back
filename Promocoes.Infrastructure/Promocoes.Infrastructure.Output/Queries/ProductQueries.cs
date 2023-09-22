using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Output.Queries
{
    public class ProductQueries : BaseQuery
    {
        public QueryModel GetAllProducts()
        {
            this.Table = Map.GetTableProduct();

            this.Query = $@"
            SELECT
	            tp.IdProduct as IdProduto,
	            tp.IdBusiness as IdEmpresa,
	            tp.Name as Nome,
	            tp.Description as Descricao,
	            tp.Images as Imagens,
	            tp.Price as Preco
            FROM 
	            {this.Table} tp 
            ";

            return new QueryModel(this.Query, null);
        }

        public QueryModel GetProductsByIdBusiness(Guid idEmpresa)
        {
            this.Table = Map.GetTableProduct();

            this.Query = @$"
            SELECT
                tp.IdProduct as IdProduto,
                tp.IdBusiness as IdEmpresa,
                tp.Name as Nome,
                tp.Description as Descricao,
                tp.Images as Imagens,
                tp.Price as Price
            FROM 
                {this.Table} tp WHERE IdBusiness = @id
            ";

            this.Parameters = new {
                id = idEmpresa
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}