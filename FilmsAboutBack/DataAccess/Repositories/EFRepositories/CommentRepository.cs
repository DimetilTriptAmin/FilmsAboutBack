using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class CommentRepository : CRUDRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context):base(context)
        {
        }

        async public Task<IEnumerable<Comment>> GetAllByFilmIdAsync(int id)
        {
            return await _context.Set<Comment>().Where<Comment>(item => item.Film.Id == id).ToListAsync();
        }
    }
}
