using FilmsAboutBack.DataAccess.Repositories.EFRepositories;
using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepository
{
    public class FilmRepository : CRUDRepository<Film>, IFilmRepository
    {

        public FilmRepository(DbContext context) : base(context)
        {
        }

        async public Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _context.Set<Film>().ToListAsync();
        }
    }
}
