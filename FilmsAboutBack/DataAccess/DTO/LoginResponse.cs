using FilmsAboutBack.Models;
using System.Text;

namespace FilmsAboutBack.DataAccess.DTO
{
    public class LoginResponse
    {
        public string JwtToken { get; set; }
        public string Username { get; set; }


        // [JsonIgnore] // cause refresh token returns in http only cookie
        // public string RefreshToken { get; set; }
        public LoginResponse(User user, string jwtToken)
        {
            Username = user.UserName;
            JwtToken = jwtToken;
        }
    }
}
