using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Model
{
    public class User : IdentityUser
    {
        public byte[] Avatar { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
