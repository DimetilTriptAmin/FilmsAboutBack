using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface IFilmService
    {
        Task<GenericResponse<IEnumerable<Film>>> GetAllAsync();
        Task<GenericResponse<Film>> GetFilmAsync(int id);
        Task<GenericResponse<int>> GetFilmIdAsync(string title);
    }
}
