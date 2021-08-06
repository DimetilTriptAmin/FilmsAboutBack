using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IRatingService
    {
        Task<RatingResponse> GetUserRatingAsync(int userId, int filmId);
        Task<double> GetRatingAsync(int filmId);
        Task<bool> SetRatingAsync(int rate, int filmId, int userId);
    }
}
