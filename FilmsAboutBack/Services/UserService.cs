using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using FilmsAboutBack.TokenGenerators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
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
                throw new ArgumentException("No such username.");
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            
            if (!isPasswordCorrect)
            {
                throw new ArgumentException("Password does not match.");
            }

            var accessToken = _generator.GenerateAccessToken(user);
            var refreshToken = _generator.GenerateRefreshToken();

            return new LoginResponse(accessToken, refreshToken);
        }

        public async Task<LoginResponse> RegisterUser(RegisterRequest registerRequest)
        {
            var user = await _userManager.FindByNameAsync(registerRequest.Username);
            if (user != null) throw new ArgumentException("This username is taken.");

            user = await _userManager.FindByEmailAsync(registerRequest.Email);
            if (user != null) throw new ArgumentException("This email is registered.");

            if (registerRequest.Password!=registerRequest.ConfirmPassword) throw new ArgumentException("Passwords must be equal.");

            user = new User()
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(",",result.Errors.Select(e=>e.Description)));
            }

            var accessToken = _generator.GenerateAccessToken(user);
            var refreshToken = _generator.GenerateRefreshToken();

            return new LoginResponse(accessToken, refreshToken);
        }
    }
}
