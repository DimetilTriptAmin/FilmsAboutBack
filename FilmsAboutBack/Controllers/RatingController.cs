using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : CRUDController<Rating>
    {
        private IRatingService _ratingService;

        public RatingController(IRatingService ratingService) : base(ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("getByPair")]
        public async Task<int> GetByPairIdAsync(int filmId, int userId)
        {
            return await _ratingService.GetByPairIdAsync(userId, filmId);
        }

        [HttpGet("forFilm{filmId}")]
        public async Task<float> GetRatingByFilmId(int filmId)
        {
            return await _ratingService.GetRatingByIdAsync(filmId);
        }

    }
}
