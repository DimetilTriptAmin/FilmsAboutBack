using FilmsAboutBack.Helpers;
using FilmsAboutBack.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmsAboutBack.TokenGenerators
{
    public class JwtGenerator
    {
        private IConfiguration _configuration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user) => GenerateToken(
           "Jwt:AccessSecret",
           10,
           new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id))
           });

        public string GenerateRefreshToken() => GenerateToken("Jwt:RefreshSecret", Constants.MINUTES_IN_MONTH);

        private string GenerateToken(string secretKey, double expiresInMinutes, Claim[] claims = null)
        {
            var issuer = _configuration.GetValue<string>("Jwt:Issuer");
            var audience = _configuration.GetValue<string>("Jwt:Audience");
            var key = _configuration.GetValue<string>(secretKey);

            var encodedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(encodedKey, algorithm);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expiresInMinutes),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJson;
        }
    }
}
