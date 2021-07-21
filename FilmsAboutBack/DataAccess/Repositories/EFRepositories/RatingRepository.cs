using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class RatingRepository : IRatingRepository
    {
        private DbContext _context;

        public RatingRepository(DbContext context)
        {
            _context = context;
        }

        async public void Create(Rating item)
        {
            await _context.Set<Rating>().AddAsync(item);
        }

        async public Task<Rating> Get(Rating item)
        {
            return await _context.Set<Rating>().FindAsync(item);
        }

        async public Task<Rating> GetByPairId(string userId, int filmId)
        {
            return await _context.Set<Rating>().FirstOrDefaultAsync(r => r.Film.Id == filmId && r.User.Id == userId);
        }

        public void Remove(Rating item)
        {
            _context.Set<Rating>().Remove(item);
        }

        public void Update(Rating item)
        {
            _context.Set<Rating>().Update(item);
        }
    }
}
