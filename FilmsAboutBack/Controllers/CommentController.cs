using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private TokenDecoder _tokenDecoder;

        public CommentController(ICommentService commentService, TokenDecoder tokenDecoder)
        {
            _commentService = commentService;
            _tokenDecoder = tokenDecoder;
        }

        [HttpGet("getAll{filmId}")]
        public async Task<IActionResult> GetAllByFilmIdAsync(int filmId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inputs.");
            }

            var response = await _commentService.GetAllByFilmIdAsync(filmId);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("createComment")]
        public async Task<IActionResult> CreateCommentAsync([FromBody]CreateCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inputs.");
            }

            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];
            var userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _commentService.CreateCommentAsync(userId, request.FilmId, request.Text);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("deleteComment/{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inputs.");
            }

            var response = await _commentService.DeleteCommentAsync(id);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

    }
}
