using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsAboutBack.Models
{
    public class User : IdentityUser<int>
    {
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
