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
    public class ReadBusinessRepository :  IReadBusinessRepository
    {
        private readonly IDbConnection _connection;

        public ReadBusinessRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public IEnumerable<BusinessDTO> GetAllBusiness()
        {
            var query = new BusinessQueries().GetAllBusinessQuery();

            try
            {
                using(_connection)
                {
                  return _connection.Query<BusinessDTO>(query.Query, query.Parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($@"Erro ao buscar empresas: {ex.Message}");
            }
        }
    }
}