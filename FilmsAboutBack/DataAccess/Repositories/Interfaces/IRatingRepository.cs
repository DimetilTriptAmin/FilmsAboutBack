using FilmsAboutBack.Models;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IRatingRepository : ICRUDRepository<Rating>
    {
        Task<Rating> GetByPairId(int userId, int filmId);
    }
}
