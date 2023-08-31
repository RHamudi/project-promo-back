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
    public class WriteBusinessRepository : IWriteBusinessRepository
    {
        private readonly IDbConnection _connection;

        public WriteBusinessRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public void InsertBusiness(BusinessEntity business)
        {
            var query = new BusinessQueries().InsertBusinessQuery(business);

            try
            {
                using(_connection)
                {
                    _connection.Execute(query.Query, query.Parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno: {ex.Message}");
            }
        }
    }
}