using FilmsAboutBack.DataAccess.DTO;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IConfiguration config) : base(unitOfWork, unitOfWork.UserRepository)
        {
            _userManager = userManager;
            _config = config;
        }

        public string HashPassword(User user, string password) => _userManager.PasswordHasher.HashPassword(user, password);

        public async Task<Result<LoginResponse>> LoginUser(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);

            if(user == null)
            {
                return Result<LoginResponse>.BadRequest($"no such username");
            }

            var isPasswordCorrect = await _userManager.HasPasswordAsync(user)/*.CheckPasswordAsync(user, loginRequest.Password)*/;

            if (!isPasswordCorrect)
            {
                return Result<LoginResponse>.BadRequest("password does not match");
            }

            var token = GenerateJwtToken(user);

            var authResponseUser = new LoginResponse(user, token);

            return Result<LoginResponse>.Success(authResponseUser);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id))
            };

            var issuer = _config.GetValue<string>("Jwt:Issuer");
            var audience = _config.GetValue<string>("Jwt:Audience");
            var secretKey = _config.GetValue<string>("Jwt:Secret");

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(10),
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
