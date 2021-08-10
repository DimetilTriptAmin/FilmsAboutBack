using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ControllerValidation]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        private TokenDecoder _tokenDecoder;

        public CommentController(ICommentService commentService, TokenDecoder tokenDecoder)
        {
            _commentService = commentService;
            _tokenDecoder = tokenDecoder;
        }

        [HttpGet("getAll{filmId}")]
        public async Task<IActionResult> GetAllByFilmIdAsync(int filmId)
        {
            var response = await _commentService.GetAllByFilmIdAsync(filmId);

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("createComment")]
        public async Task<IActionResult> CreateCommentAsync([FromBody]CreateCommentRequest request)
        {
            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];
            var userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _commentService.CreateCommentAsync(userId, request.FilmId, request.Text);

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("deleteComment/{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            var response = await _commentService.DeleteCommentAsync(id);

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

    }
}
