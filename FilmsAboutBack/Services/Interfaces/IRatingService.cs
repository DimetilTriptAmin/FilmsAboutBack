using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IRatingService : ICRUDService<Rating>
    {
        Task<int?> GetByPairIdAsync(int userId, int filmId);
        Task<double> GetRatingByIdAsync(int filmId);
        Task<bool> SetRatingAsync(int rate, int filmId, int userId);
    }
}
