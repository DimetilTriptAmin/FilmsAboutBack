using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsAboutBack.Models
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "varchar(max)")]
        public byte[] Avatar { get; set; }
        public DateTime BirthDate { get; set; } // delete
        [Column(TypeName = "varchar(max)")]
        public string refreshToken { get; set; }
    }
}
