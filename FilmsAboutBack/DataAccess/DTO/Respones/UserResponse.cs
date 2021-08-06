using FilmsAboutBack.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace FilmsAboutBack.DataAccess.DTO.Respones
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
    }
}
