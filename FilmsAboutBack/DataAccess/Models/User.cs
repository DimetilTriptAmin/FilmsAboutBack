using Microsoft.AspNetCore.Identity;
using System;

namespace FilmsAboutBack.Models
{
    public class User : IdentityUser
    {
        public byte[] Avatar { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
