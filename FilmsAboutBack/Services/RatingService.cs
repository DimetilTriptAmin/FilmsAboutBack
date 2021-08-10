using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class RatingService : ServiceBase, IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<GenericResponse<RatingResponse>> GetUserRatingAsync(int userId, int filmId)
        {
            try
            {
                var request = await _unitOfWork.RatingRepository.Filter(rating => rating.UserId == userId && rating.FilmId == filmId);
                var rating = request.FirstOrDefault();

                var response = new RatingResponse() { Rate = rating == null ? 0 : rating.Rate, UserId = userId };
                return new GenericResponse<RatingResponse>(response);
            }
            catch
            {
                return new GenericResponse<RatingResponse>("Internal server error.");
            }
        }

        public async Task<GenericResponse<bool>> SetRatingAsync(int rate, int filmId, int userId)
        {
            try
            {
                var request = await _unitOfWork.RatingRepository.Filter(rating => rating.UserId == userId && rating.FilmId == filmId);
                var currentRating = request.FirstOrDefault();

                Rating rating = new Rating()
                {
                    Rate = rate,
                    FilmId = filmId,
                    UserId = userId,
                };

                if (currentRating != null)
                {
                    currentRating.Rate = rate;
                }
                else await _unitOfWork.RatingRepository.CreateAsync(rating);
                await _unitOfWork.SaveAsync();

                var film = await _unitOfWork.FilmRepository.GetAsync(filmId);
                film.Rating = await GetRatingAsync(filmId);
                await _unitOfWork.SaveAsync();

                return new GenericResponse<bool>(true);
            }
            catch
            {
                return new GenericResponse<bool>("Internal server error.");
            }
        }

        private async Task<double> GetRatingAsync(int filmId)
        {
            var request = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == filmId);
            var rates = request.Select(rating => rating.Rate);
            return rates.Average(value => value);
        }
    }
}
