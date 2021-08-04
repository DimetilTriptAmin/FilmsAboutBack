using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class RatingRepository : CRUDRepository<Rating>, IRatingRepository
    {
        public RatingRepository(DbContext context) : base(context)
        {
        }

        async public Task<int?> GetByPairIdAsync(int userId, int filmId)
        {
             var actualRating = await _context.Set<Rating>()
                .FirstOrDefaultAsync(r => r.Film.Id == filmId && r.User.Id == userId);
            return actualRating?.Rate;
        }

        async public Task<IEnumerable<int>> GetAllRatesByIdAsync(int filmId)
        {
            return await Task.Run(() => _context.Set<Rating>()
            .Where(r => r.FilmId == filmId)
            .Select(r => r.Rate));
        }
    }
}
