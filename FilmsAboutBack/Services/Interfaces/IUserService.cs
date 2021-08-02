using FilmsAboutBack.DataAccess.DTO;
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
        public Task<Result<LoginResponse>> LoginUser(LoginRequest loginRequest);
    }
}
