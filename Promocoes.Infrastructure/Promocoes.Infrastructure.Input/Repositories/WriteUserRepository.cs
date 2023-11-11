using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Promocoes.Application.Input.Commands.UserContext;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Domain.Entities;
using Promocoes.Infrastructure.Input.Queries;
using Promocoes.Infrastructure.Shared.Factory;

namespace Promocoes.Infrastructure.Input.Repositories
{
    public class WriteUserRepository : IWriteUserRepository
    {
        private readonly IDbConnection _connection;

        public WriteUserRepository()
        {
            _connection = SqlFactory.SqlFactoryConnection();
        }

        public void InsertUser(UserEntity user)
        {
            var query = new UserQueries().InsertUser(user);

            try
            {
                using(_connection)
                {
                    _connection.Query(query.Query, query.Parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserByIdDTO GetUserById(Guid user)
        {
            var query = new UserQueries().GetUserById(user);

            try
            {
                using(_connection)
                {
                    return _connection.QueryFirstOrDefault<UserByIdDTO>(query.Query, query.Parameters);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(UserEntity user)
        {
            var query = new UserQueries().UpdateUser(user);

            try
            {
                using(_connection)
                {
                    _connection.Query(query.Query, query.Parameters);
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}