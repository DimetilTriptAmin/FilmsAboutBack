using Microsoft.AspNetCore.Identity;
using System;

namespace FilmsAboutBack.Models
{
    public class User : IdentityUser<int>
    {
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
