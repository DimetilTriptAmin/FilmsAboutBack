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
    [Route("api/[controller]")]
    public class RatingController : CRUDController<Rating>
    {
        private IRatingService _ratingService;
        private TokenDecoder _tokenDecoder;

        public RatingController(
            IRatingService ratingService, 
            TokenDecoder tokenDecoder
            ) : base(ratingService)
        {
            _ratingService = ratingService;
            _tokenDecoder = tokenDecoder;
        }

        [HttpGet("getByPair")]
        public async Task<IActionResult> GetByPairIdAsync(int filmId, int userId)
        {
            var response = await _ratingService.GetByPairIdAsync(userId, filmId);
            return Ok(response);
        }

        [HttpGet("forFilm{filmId}")]
        public async Task<double> GetRatingByFilmIdAsync(int filmId)
        {
            return await _ratingService.GetRatingByIdAsync(filmId);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("ratingForFilm/{filmId}")]
        //public async Task<IActionResult> GetCurrentRatingByFilmIdAsync(int filmId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid inputs.");
        //    }

        //    var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];
        //    var userId = _tokenDecoder.getUserIdFromToken(token);

        //    var result = await _ratingService.SetRatingAsync(setRatingRequest.Rate, setRatingRequest.FilmId, userId);

        //    if (!result)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();

        //    return await _ratingService.GetRatingByIdAsync(filmId);
        //}

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

            var result = await _ratingService.SetRatingAsync(setRatingRequest.Rate, setRatingRequest.FilmId, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
