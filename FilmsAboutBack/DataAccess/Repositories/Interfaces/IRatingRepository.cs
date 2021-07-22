using FilmsAboutBack.Models;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetByPairIdAsync(int userId, int filmId);
    }
}
