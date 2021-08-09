using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private IRatingService _ratingService;
        private TokenDecoder _tokenDecoder;

        public RatingController(
            IRatingService ratingService, 
            TokenDecoder tokenDecoder
            )
        {
            _ratingService = ratingService;
            _tokenDecoder = tokenDecoder;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getUserRating{filmId}")]
        public async Task<IActionResult> GetUserRatingAsync(int filmId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inputs.");
            }

            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];
            var userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _ratingService.GetUserRatingAsync(userId, filmId);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("rateFilm")]
        public async Task<IActionResult> RateFilmAsync([FromBody] SetRatingRequest setRatingRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inputs.");
            }

            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];
            var userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _ratingService.SetRatingAsync(setRatingRequest.Rate, setRatingRequest.FilmId, userId);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

    }
}
