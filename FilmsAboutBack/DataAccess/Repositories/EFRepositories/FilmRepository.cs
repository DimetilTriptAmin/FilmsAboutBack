using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepository
{
    public class FilmRepository : IFilmRepository
    {
        private DbContext _context;

        public FilmRepository(DbContext context)
        {
            _context = context;
        }

        async public void Create(Film item)
        {
            await _context.Set<Film>().AddAsync(item);
        }

        async public Task<Film> Get(Film item)
        {
            return await _context.Set<Film>().FindAsync(item);
        }

        async public Task<IEnumerable<Film>> GetAll()
        {
            return await _context.Set<Film>().ToListAsync();
        }

        async public Task<Film> GetById(int id)
        {
            return await _context.Set<Film>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public void Remove(Film item)
        {
            _context.Set<Film>().Remove(item);
        }

        public void Update(Film item)
        {
            _context.Set<Film>().Update(item);
        }
    }
}
