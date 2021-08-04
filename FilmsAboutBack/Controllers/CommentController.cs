using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : CRUDController<Comment>
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService) : base(commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("forFilm{id}")]
        public async Task<IEnumerable<Comment>> GetAllByFilmIdAsync(int id)
        {
            return await _commentService.GetAllByFilmIdAsync(id);
        }

    }
}
