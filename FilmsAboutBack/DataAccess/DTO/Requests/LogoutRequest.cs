using System.ComponentModel.DataAnnotations;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class LogoutRequest
    {
        [Required]
        public string AccessToken { get; set; }
    }
}
