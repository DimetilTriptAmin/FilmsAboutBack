using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class FilmService : ServiceBase, IFilmService
    {
        public FilmService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<GenericResponse<IEnumerable<Film>>> GetAllAsync()
        {
            try
            {
                var response = await _unitOfWork.FilmRepository.GetAllAsync();

                if (response == null)
                {
                    return new GenericResponse<IEnumerable<Film>>("Films not found.");
                }

                return new GenericResponse<IEnumerable<Film>>(response);
            }
            catch
            {
                return new GenericResponse<IEnumerable<Film>>("Internal server error.");
            }
        }

        public async Task<GenericResponse<Film>> GetFilmAsync(int id)
        {
            try
            {
                var response = await _unitOfWork.FilmRepository.GetAsync(id);

                if (response == null)
                {
                    return new GenericResponse<Film>("Film not found.");
                }

                return new GenericResponse<Film>(response);
            }
            catch
            {
                return new GenericResponse<Film>("Internal server error.");
            }
        }

        public async Task<GenericResponse<int>> GetFilmIdAsync(string title)
        {
            try
            {
                var filmRequest = await _unitOfWork.FilmRepository.Filter(film => film.Title == title);
                var response = filmRequest.FirstOrDefault();

                if (response == null)
                {
                    return new GenericResponse<int>("Film not found.");
                }

                return new GenericResponse<int>(response.Id);
            }
            catch
            {
                return new GenericResponse<int>("Internal server error.");
            }
        }
    }
}
