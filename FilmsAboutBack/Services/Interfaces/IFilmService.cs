using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAll();
    }
}
