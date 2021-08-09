using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class SetRatingRequest
    {
        [Required]
        public int FilmId { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }
    }
}
