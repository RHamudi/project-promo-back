using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;
using Promocoes.Infrastructure.Output.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Output.Repositories
{
    public class ReadPromotionRepository : IReadPromotionRepository
    {
        private readonly IDbConnection _connection;

        public ReadPromotionRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public IEnumerable<PromotionDTO> GetAllPromotions()
        {
            var query = new PromotionsQueries().GetAllPromotions();

            try
            {
                using(_connection)
                {
                    return _connection.Query<PromotionDTO>(query.Query, query.Parameters);
                }
            }
            catch
            {
                throw new Exception("Não foi possivel coletar promoçoes");
            }
        }
    }
}