using FilmsAboutBack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IFilmRepository : ICRUDRepository<Film>
    {
        Task<IEnumerable<Film>> GetAllAsync();
    }
}
