using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class UpdateRequest
    {
        [Required]
        public byte[] Avatar { get; set; }
    }
}
