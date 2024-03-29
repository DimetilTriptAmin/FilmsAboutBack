﻿using FilmsAboutBack.Helpers;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ControllerValidation]
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
            var response = await _filmService.GetFilmAsync(id);
            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

        [HttpGet("getId/{title}")]
        public async Task<IActionResult> GetFilmIdAsync(string title)
        {
            var response = await _filmService.GetFilmIdAsync(title);
            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

    }
}
