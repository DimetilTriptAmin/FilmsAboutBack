using FilmsAboutBack.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;

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
    }
}
