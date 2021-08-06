using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class FilmService : ServiceBase, IFilmService
    {
        public FilmService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Film>> GetAllAsync() => await _unitOfWork.FilmRepository.GetAllAsync();

        public async Task<Film> GetFilmAsync(int id) => await _unitOfWork.FilmRepository.GetAsync(id);

    }
}
