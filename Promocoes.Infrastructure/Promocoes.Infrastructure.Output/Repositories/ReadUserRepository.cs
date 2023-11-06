using System.Data;
using Dapper;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;
using Promocoes.Infrastructure.Output.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Output.Repositories
{
    public class ReadUserRepository : IReadUserRepository
    {
        private readonly IDbConnection _connection;

        public ReadUserRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var query = new UserQueries().GetAllUsers();

            try
            {
                using(_connection)
                {
                    return _connection.Query<UserDTO>(query.Query, query.Parameters);
                }
            }
            catch
            {
                throw new Exception("Não foi possivel coletar usuarios");
            }
        }
    }
}