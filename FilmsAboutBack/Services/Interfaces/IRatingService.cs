using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Helpers;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IRatingService
    {
        Task<GenericResponse<RatingResponse>> GetUserRatingAsync(int userId, int filmId);
        Task<GenericResponse<double>> SetRatingAsync(int rate, int filmId, int userId);
    }
}
