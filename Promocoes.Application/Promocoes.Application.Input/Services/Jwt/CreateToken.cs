using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Promocoes.Application.Input.Commands.BusinessContext;

namespace Promocoes.Application.Input.Services.Jwt
{
    public class CreateToken
    {
        public CreateToken(AuthenticationCommand model)
        {
            GenerateToken(model);
        }
        public string Token { get; private set; }
        private void GenerateToken(AuthenticationCommand model)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, model.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(@"485c19d96ff6875f9afe0398d03886dd3a6ca71d"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            this.Token = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
