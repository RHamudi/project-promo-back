using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Promocoes.Application.Input.Receivers;

namespace Promocoes.Application.Input.Services.Jwt
{
    public class ValidateToken
    {
        public static bool VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("485c19d96ff6875f9afe0398d03886dd3a6ca71d")),
                ValidateIssuer = false, // Defina como 'true' e forneça o Issuer (emissor) correto se quiser validar o emissor.
                ValidateAudience = false, // Defina como 'true' e forneça a Audience (audiência) correta se quiser validar a audiência.
                ClockSkew = TimeSpan.Zero // Define o tempo de tolerância para expiração de tokens (opcional).
            };
        }
    }
}
