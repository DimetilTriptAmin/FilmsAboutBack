using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IRatingService : ICRUDService<Rating>
    {
        Task<Rating> GetByPairIdAsync(int userId, int filmId);
        Task<float> GetRatingByIdAsync(int filmId);
    }
}
