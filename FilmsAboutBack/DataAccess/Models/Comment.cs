using System;

namespace FilmsAboutBack.Models
{
    public class Comment
    {
        public User User { get; set; }
        public Film Film { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
