using FilmsAboutBack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IRatingRepository : ICRUDRepository<Rating>
    {
        Task<int?> GetByPairIdAsync(int userId, int filmId);
        Task<IEnumerable<int>> GetAllRatesByIdAsync(int filmId);
    }
}
