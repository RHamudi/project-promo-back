using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;


namespace Promocoes.Infrastructure.Shared.Factory
{
    public class SqlFactory
    {
        public static IDbConnection SqlFactoryConnection()
        {   //NpgsqlConnection("Server=project-promo-11154.6wr.aws-us-west-2.cockroachlabs.cloud;Port=26257;Database=defaultdb;Username=project-promo;Password=TqkXkqn_G9OAEz5u0aITkQ;");
            // SqlConnection("Server=localhost;Database=promo_database;Trusted_Connection=True;TrustServerCertificate=True;");
            return new NpgsqlConnection("Server=project-promo-11154.6wr.aws-us-west-2.cockroachlabs.cloud;Port=26257;Database=defaultdb;Username=project-promo;Password=TqkXkqn_G9OAEz5u0aITkQ;");
        }
    }
}