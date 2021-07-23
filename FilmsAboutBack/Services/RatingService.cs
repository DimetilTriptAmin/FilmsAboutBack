using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
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
    }
}
