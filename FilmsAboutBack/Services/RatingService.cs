using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class RatingService : CRUDService<Rating>, IRatingService
    {
        private IUnitOfWork _unitOfWork;

        public RatingService(IUnitOfWork unitOfWork) : base(unitOfWork.RatingRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Rating> GetByPairIdAsync(int userId, int filmId)
        {
            return await _unitOfWork.RatingRepository.GetByPairIdAsync(userId, filmId);
        }
    }
}
