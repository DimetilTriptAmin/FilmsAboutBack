namespace FilmsAboutBack.Models
{
    public class Rating
    {
        /// <summary>
        ///     Change fields
        /// </summary>
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public int Rate { get; set; }
    }
}
