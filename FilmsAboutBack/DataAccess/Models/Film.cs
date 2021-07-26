namespace FilmsAboutBack.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Poster { get; set; }
        public string Description { get; set; }
        public string TrailerLink { get; set; }
        public float Rating { get; set; }
    }
}
