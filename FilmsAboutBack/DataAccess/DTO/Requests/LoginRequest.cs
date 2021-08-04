using System.ComponentModel.DataAnnotations;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
