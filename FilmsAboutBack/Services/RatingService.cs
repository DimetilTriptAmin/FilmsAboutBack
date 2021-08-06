using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class RatingService : CRUDService<Rating>, IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RatingRepository)
        {
        }

        public async Task<RatingResponse> GetByPairIdAsync(int userId, int filmId)
        {
            var rating = await _unitOfWork.RatingRepository.GetByPairIdAsync(userId, filmId);
            var response = new RatingResponse() { Rate = rating.Rate, UserId = rating.UserId };
            return response;
        }

        public async Task<double> GetRatingByIdAsync(int filmId)
        {
            var rates = _unitOfWork.RatingRepository.GetAllRatesByIdAsync(filmId).Result;
            return await Task.Run(() => rates.Average<int>(value => value));
        }

        public async Task<bool> SetRatingAsync(int rate, int filmId, int userId)
        {
            try
            {
                var actualRate = await GetByPairIdAsync(userId, filmId);

                Rating rating = new Rating()
                {
                    Rate = rate,
                    FilmId = filmId,
                    UserId = userId,
                };

                if (actualRate != null) await _unitOfWork.RatingRepository.UpdateAsync(rating);
                else await _unitOfWork.RatingRepository.CreateAsync(rating);
                await _unitOfWork.SaveAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
