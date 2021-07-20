namespace FilmsAboutBack.Models
{
    public class Rating
    {
        public User User { get; set; }
        public Film Film { get; set; }
        public int Rate { get; set; }
    }
}
