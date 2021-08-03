using FilmsAboutBack.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace FilmsAboutBack.DataAccess.DTO.Respones
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }

        public LoginResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
