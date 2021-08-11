using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Helpers;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IUserService
    {
        public Task<GenericResponse<LoginResponse>> LoginUserAsync(LoginRequest loginRequest);
        public Task<GenericResponse<UpdateResponse>> UpdateAsync(int userId, UpdateRequest updateRequest);
        public Task<GenericResponse<LoginResponse>> RegisterUserAsync(RegisterRequest registerRequest);
        public Task<GenericResponse<LoginResponse>> RefreshAsync(string token);
        public Task<GenericResponse<bool>> LogoutAsync(int id);
        public Task<GenericResponse<UserResponse>> GetUserAsync(int id);
        public Task<GenericResponse<bool>> ChangePasswordAsync(int id, ChangePasswordRequest changePasswordRequest);
    }
}
