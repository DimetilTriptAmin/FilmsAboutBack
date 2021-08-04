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
        private readonly JwtGenerator _generator;

        public UserService(
            IUnitOfWork unitOfWork, 
            UserManager<User> userManager,
            JwtGenerator generator
            ) : base(unitOfWork, unitOfWork.UserRepository)
        {
            _userManager = userManager;
            _generator = generator;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
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

            LoginResponse response = AuthorizeUser(user);
            user.refreshToken = response.RefreshToken;
            await _userManager.UpdateAsync(user);

            return response;
        }

        public async Task<LoginResponse> RefreshAsync(string token)
        {
            User user = await _unitOfWork.UserRepository.GetUserByRefreshTokenAsync(token);
            LoginResponse response = AuthorizeUser(user);
            user.refreshToken = response.RefreshToken;
            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
            return response;
        }

        public async Task<LoginResponse> RegisterUserAsync(RegisterRequest registerRequest)
        {
            var user = await _userManager.FindByNameAsync(registerRequest.Username);
            if (user != null) throw new ArgumentException("This username is taken.");

            user = await _userManager.FindByEmailAsync(registerRequest.Email);
            if (user != null) throw new ArgumentException("This email is registered.");

            if (registerRequest.Password != registerRequest.ConfirmPassword) throw new ArgumentException("Passwords must be equal.");

            user = new User()
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            LoginResponse response = AuthorizeUser(user);
            user.refreshToken = response.RefreshToken;

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));
            }

            return response;
        }

        private LoginResponse AuthorizeUser(User user)
        {
            var accessToken = _generator.GenerateAccessToken(user);
            var refreshToken = _generator.GenerateRefreshToken();

            return new LoginResponse(accessToken, refreshToken);
        }
    }
}
