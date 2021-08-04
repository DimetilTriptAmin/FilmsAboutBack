using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [Route("api/[controller]")]
    public class FilmController : CRUDController<Film>
    {
        private IFilmService _filmService;

        public FilmController(IFilmService filmService) : base(filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _filmService.GetAllAsync();
        }

    }
}
