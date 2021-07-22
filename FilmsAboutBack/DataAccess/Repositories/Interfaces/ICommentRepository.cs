using FilmsAboutBack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllByFilmIdAsync(int id);
    }
}
