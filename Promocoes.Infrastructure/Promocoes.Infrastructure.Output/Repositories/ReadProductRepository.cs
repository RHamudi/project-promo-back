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
    public class ReadProductRepository : IReadProductRepository
    {
        private readonly IDbConnection _connection;

        public ReadProductRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var query = new ProductQueries().GetAllProducts();
            
            try
            {
                using(_connection)
                {
                    return _connection.Query<ProductDTO>(query.Query, query.Parameters);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($@"Erro ao buscar produtos: {ex.Message}");
            }
        }

        public IEnumerable<ProductDTO> GetProductsByBusinessId(Guid idEmpresa)
        {
            var query = new ProductQueries().GetProductsByIdBusiness(idEmpresa);

            try
            {   
                using(_connection)
                {
                    return _connection.Query<ProductDTO>(query.Query, query.Parameters);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao buscar produtos: {ex.Message}");
            }
        }
    }
}