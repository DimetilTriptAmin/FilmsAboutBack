using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class FilmService : CRUDService<Film>, IFilmService
    {
        public FilmService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.FilmRepository)
        {
        }

        public async Task<IEnumerable<Film>> GetAllAsync() => await _unitOfWork.FilmRepository.GetAllAsync();
    }
}
