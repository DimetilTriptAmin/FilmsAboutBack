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

        public async Task<int> GetByPairIdAsync(int userId, int filmId)
        {
            return await _unitOfWork.RatingRepository.GetByPairIdAsync(userId, filmId);
        }

        public async Task<double> GetRatingByIdAsync(int filmId)
        {
            var rates = _unitOfWork.RatingRepository.GetAllRatesByIdAsync(filmId).Result;
            return await Task.Run(() => rates.Average<int>(value => value));
        }
    }
}
