using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class RatingService : ServiceBase, IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<RatingResponse> GetUserRatingAsync(int userId, int filmId)
        {
            try
            {
                var request = await _unitOfWork.RatingRepository.Filter(rating => rating.UserId == userId && rating.FilmId == filmId);
                var rating = request.FirstOrDefault();
                var response = new RatingResponse() { Rate = rating.Rate, UserId = rating.UserId };
                return response;
            }
            catch
            {
                return null;
            }
        }

        public async Task<double> GetRatingAsync(int filmId)
        {
            try
            {
                var request = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == filmId);
                var rates = request.Select(rating => rating.Rate);
                return await Task.Run(() => rates.Average(value => value));
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> SetRatingAsync(int rate, int filmId, int userId)
        {
            try
            {
                var actualRate = await GetUserRatingAsync(userId, filmId);

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
