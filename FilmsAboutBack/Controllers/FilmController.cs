using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _filmService.GetAllAsync();
            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmAsync(int id)
        {

            if(!ModelState.IsValid) return BadRequest("Invalid input.");

            var response = await _filmService.GetFilmAsync(id);
            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

    }
}
