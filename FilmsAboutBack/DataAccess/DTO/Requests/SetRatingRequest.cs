using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class SetRatingRequest
    {
        public int FilmId { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
    }
}
