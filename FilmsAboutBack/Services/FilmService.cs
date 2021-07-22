using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class FilmService : CRUDService<IFilmRepository, Film>, IFilmService
    {
        private IUnitOfWork _unitOfWork;

        public FilmService(IUnitOfWork unitOfWork) : base(unitOfWork.FilmRepository)
        {
            _unitOfWork = unitOfWork;
        }

        async public Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _unitOfWork.FilmRepository.GetAllAsync();
        }
    }
}
