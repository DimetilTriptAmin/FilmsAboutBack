using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Models
{
    public class Rating
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public int Rate { get; set; }
    }
}
