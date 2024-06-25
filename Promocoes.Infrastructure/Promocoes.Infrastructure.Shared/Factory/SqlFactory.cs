using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;


namespace Promocoes.Infrastructure.Shared.Factory
{
    public class SqlFactory
    {

        public static IDbConnection SqlFactoryConnection()
        {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();
  
            var apiKey = Environment.GetEnvironmentVariable("SQL_COCKROACHDB");
            return new NpgsqlConnection(apiKey);
        }
    }
}