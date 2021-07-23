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

        public async Task<Rating> GetByPairIdAsync(int userId, int filmId)
        {
            return await _unitOfWork.RatingRepository.GetByPairIdAsync(userId, filmId);
        }

        public async Task<float> GetRatingByIdAsync(int filmId)
        {
            var rates = _unitOfWork.RatingRepository.GetAllRatesByIdAsync(filmId).Result.ToList();
            return await Task.Run(() => rates.Aggregate(0, (acc, value) => acc + value) / (float)rates.Count);
        }
    }
}
