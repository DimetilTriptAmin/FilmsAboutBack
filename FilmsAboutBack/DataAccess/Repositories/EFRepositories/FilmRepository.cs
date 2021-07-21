using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepository
{
    public class FilmRepository : IFilmRepository
    {
        private DbContext _context;
        //dbset removed to fix exceptions

        public FilmRepository(DbContext context)
        {
            _context = context;
        }

        async public Task<IEnumerable<Film>> GetAll()
        {
            return await _context.Set<Film>().ToListAsync();
        }
    }
}
