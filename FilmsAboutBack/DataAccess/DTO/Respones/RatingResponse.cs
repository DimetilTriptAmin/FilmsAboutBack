using FilmsAboutBack.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace FilmsAboutBack.DataAccess.DTO.Respones
{
    public class RatingResponse
    {
        public int UserId{ get; set; }
        public int Rate { get; set; }
    }
}
