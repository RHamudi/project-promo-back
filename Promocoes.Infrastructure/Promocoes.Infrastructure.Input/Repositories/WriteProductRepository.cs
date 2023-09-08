using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Input.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Input.Repositories
{
    public class WriteProductRepository : IWriteProductRepository
    {
        private readonly IDbConnection _connection;

        public WriteProductRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public void InsertProduct(ProductEntity product)
        {
            var query = new ProductQueries().InsertProduct(product);

            try 
            {
                using(_connection)
                {
                    _connection.Query(query.Query, query.Parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno: {ex.Message}");
            }
        }
    }
}