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
                    _connection.Close();
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
                UserByIdDTO retorno;
                using(_connection)
                {
                   retorno = _connection.QueryFirstOrDefault<UserByIdDTO>(query.Query, query.Parameters);
                   _connection.Close();
                   return retorno;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(UpdateUserCommand user)
        {
            var query = new UserQueries().UpdateUser(user);

            try
            {
                using(_connection)
                {
                    _connection.Query(query.Query, query.Parameters);
                    _connection.Close();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public VerifyTokenDTO VerifyUser(VerificationCommand verify)
        {
            var query = new UserQueries().VerifyTokenQuery(verify.Token);

            try
            {
                    VerifyTokenDTO token;
                    _connection.Open();
                    token = _connection.QueryFirstOrDefault<VerifyTokenDTO>(query.Query, query.Parameters);
                    _connection.Close();
                    return token;
                
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUserDate(DateTime date, string token)
        {
            var query = new UserQueries().UpdateVerifyDate(date, token);

            try
            {
                    _connection.Open();
                    _connection.Query(query.Query, query.Parameters);
                    _connection.Close();
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}