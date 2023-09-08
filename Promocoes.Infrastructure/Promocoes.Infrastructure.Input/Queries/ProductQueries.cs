using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Input.Queries
{
    public class ProductQueries : BaseQuery
    {
        public QueryModel InsertProduct(ProductEntity entity)
        {
            this.Table = Map.GetTableProduct();

            this.Query = $@"
            INSERT INTO {this.Table}
            VALUES
            (
                @IdProduct,
                @IdBusiness,
                @Name,
                @Description,
                @Images,
                @Price
            )
            ";

            this.Parameters = new {
                IdProduct = entity.IdProduct,
                IdBusiness = entity.IdBusiness,
                Name = entity.Name,
                Description = entity.Description,
                Images = entity.Images,
                Price = entity.Price
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}