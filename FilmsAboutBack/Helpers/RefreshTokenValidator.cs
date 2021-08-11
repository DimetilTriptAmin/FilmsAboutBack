using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsAboutBack.Helpers
{
    public class RefreshTokenValidator
    {
        private IConfiguration _configuration;

        public RefreshTokenValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Validate(string token)
        {
            try
            {
                var issuer = _configuration.GetValue<string>("Jwt:Issuer");
                var audience = _configuration.GetValue<string>("Jwt:Audience");
                var secretKey = _configuration.GetValue<string>("Jwt:RefreshSecret");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = key,
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
