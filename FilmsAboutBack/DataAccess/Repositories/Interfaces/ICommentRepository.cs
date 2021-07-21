using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IRatingRepository : ICRUDRepository<Rating>
    {
        Task<IEnumerable<Comment>> GetAllByFilmId(int id);
    }
}
