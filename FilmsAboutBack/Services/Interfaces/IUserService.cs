using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IUserService : ICRUDService<User>
    {
        public Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest);
        public Task<LoginResponse> RegisterUserAsync(RegisterRequest registerRequest);
        public Task<LoginResponse> RefreshAsync(string token);
        public Task<bool> LogoutAsync(int id);
    }
}
