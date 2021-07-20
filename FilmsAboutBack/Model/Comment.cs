using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Model
{
    public class Comment
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
