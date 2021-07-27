using System;

namespace FilmsAboutBack.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
