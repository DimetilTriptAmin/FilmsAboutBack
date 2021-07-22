using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class RatingRepository : CRUDRepository<Rating>, IRatingRepository
    {
        public RatingRepository(DbContext context) : base(context)
        {
        }

        async public Task<Rating> GetByPairIdAsync(int userId, int filmId)
        {
            return await _context.Set<Rating>().FirstOrDefaultAsync(r => r.Film.Id == filmId && r.User.Id == userId);
        }
    }
}
