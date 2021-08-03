using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using FilmsAboutBack.TokenGenerators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtGenerator _generator;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IConfiguration configuration, JwtGenerator generator) : base(unitOfWork, unitOfWork.UserRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _generator = generator;
        }

        public string HashPassword(User user, string password) => _userManager.PasswordHasher.HashPassword(user, password);

        public async Task<LoginResponse> LoginUser(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);

            if(user == null)
            {
                throw new ArgumentException("no such username");
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            
            //if (!isPasswordCorrect)
            //{
            //    throw new ArgumentException("password does not match");
            //}

            var accessToken = _generator.GenerateAccessToken(user);

            var refreshToken = _generator.GenerateRefreshToken();

            return new LoginResponse(accessToken, refreshToken);
        }
    }
}
