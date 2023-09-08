using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Input.Queries
{
    public class PromotionsQueries : BaseQuery
    {
        public QueryModel InsertPromotion(PromotionsEntity entity)
        {
            this.Table = Map.GetTablePromotion();

            this.Query = @$"
            INSERT INTO {this.Table}
            VALUES
            (
                @IdPromotion,
                @IdBusiness,
                @IdProduct,
                @SartDate,
                @EndDate,
                @PrevPrice,
                @DiscountedPrice,
                @Percentage
            )
            ";

            this.Parameters = new {

                IdPromotion = entity.IdPromotion,
                IdBusiness = entity.IdBusiness,
                IdProduct = entity.IdProduct,
                SartDate = entity.StartDate,
                EndDate = entity.EndDate,
                PrevPrice = entity.PrevPrice,
                DiscountedPrice = entity.DiscountedPrice,
                Percentage = entity.Percentage
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}