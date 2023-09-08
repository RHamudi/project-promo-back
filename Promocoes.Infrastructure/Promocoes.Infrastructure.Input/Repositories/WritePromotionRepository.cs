using System.Data;
using Dapper;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Input.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Input.Repositories
{
    public class WritePromotionRepository : IWritePromotionsRepository
    {
        private readonly IDbConnection _connection;

        public WritePromotionRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public void InsertPromotions(PromotionsEntity promotions)
        {
            var query = new PromotionsQueries().InsertPromotion(promotions);

            try
            {
                using(_connection)
                {
                    _connection.Query(query.Query, query.Parameters);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}