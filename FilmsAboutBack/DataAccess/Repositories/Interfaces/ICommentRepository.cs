using FilmsAboutBack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface ICommentRepository : ICRUDRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAllByFilmId(int id);
    }
}
