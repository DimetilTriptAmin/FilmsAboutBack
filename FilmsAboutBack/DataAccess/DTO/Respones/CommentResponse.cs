using System;

namespace FilmsAboutBack.DataAccess.DTO.Respones
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] Avatar { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }

        public CommentResponse(string userName, byte[] avatar, string text, int rating, DateTime publishDate)
        {
            UserName = userName;
            Avatar = avatar;
            Text = text;
            Rating = rating;
            PublishDate = publishDate;
        }
        public CommentResponse(int id, string userName, byte[] avatar, string text, int rating, DateTime publishDate)
        {
            Id = id;
            UserName = userName;
            Avatar = avatar;
            Text = text;
            Rating = rating;
            PublishDate = publishDate;
        }

    }
}
