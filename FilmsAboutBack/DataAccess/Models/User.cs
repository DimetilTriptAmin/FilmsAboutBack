using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace FilmsAboutBack.Models
{
    public class User : IdentityUser
    {
        public byte[] Avatar { get; set; }
        public DateTime BirthDate { get; set; }

        //[NotMapped]
        //public IdentityUserLogin UserLogin { get; set; }
    }
}
