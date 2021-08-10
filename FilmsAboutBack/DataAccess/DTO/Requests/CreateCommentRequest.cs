using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class CreateCommentRequest
    {
        [Required]
        public int FilmId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
