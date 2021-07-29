using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsAboutBack.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Poster { get; set; }
        public string Description { get; set; }
        public string TrailerLink { get; set; }
        public double Rating { get; set; }
    }
}
