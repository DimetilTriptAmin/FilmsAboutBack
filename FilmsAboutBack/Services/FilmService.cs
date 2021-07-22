﻿using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class FilmService : CRUDService<IFilmRepository, Film>, IFilmService
    {
        private IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository) : base(filmRepository)
        {
            _filmRepository = filmRepository;
        }

        async public Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _filmRepository.GetAllAsync();
        }
    }
}
