using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("forFilm{id}")]
        public async Task<IActionResult> GetAllByFilmIdAsync(int id)
        {
            try
            {
                var response = await _commentService.GetAllByFilmIdAsync(id);
                return Ok(response);
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
