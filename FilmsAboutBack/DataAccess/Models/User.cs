using Microsoft.AspNetCore.Identity;
using System;

namespace FilmsAboutBack.Models
{
    public class User : IdentityUser<int>
    {
        public byte[] Avatar { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
