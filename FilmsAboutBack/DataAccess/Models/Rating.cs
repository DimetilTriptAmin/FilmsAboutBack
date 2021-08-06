namespace FilmsAboutBack.Models
{
    public class Rating
    {
        //public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public int Rate { get; set; }
    }
}
