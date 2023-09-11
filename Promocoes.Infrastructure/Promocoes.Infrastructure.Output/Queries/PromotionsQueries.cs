using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Infrastructure.Shared.Shared;

namespace Promocoes.Infrastructure.Output.Queries
{
    public class PromotionsQueries : BaseQuery
    {
        public QueryModel GetAllPromotions()
        {
            this.Table = Map.GetTablePromotion();

            this.Query = $@"
            SELECT
	            tp.IdPromotion as IdPromocao,
	            tp.IdBusiness as IdEmpresa,
	            tp.IdProduct as IdProduto,
	            tp.StartDate as DataInicio,
	            tp.EndDate as DataTermino,
	            tp.PrevPrice as PrecoAnterior,
	            tp.DiscountedPrice as PrecoDesconto,
	            tp.Percentage as PorcentagemDesconto
            FROM 
	            {this.Table} tp 
            ";

            return new QueryModel(this.Query, null);
        }
    }
}