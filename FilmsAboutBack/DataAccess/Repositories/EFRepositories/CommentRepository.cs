using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepository
{
    public class CommentRepository : ICommentRepository
    {
        private DbContext _context;

        public CommentRepository(DbContext context)
        {
            _context = context;
        }

        async public void Create(Comment item)
        {
            await _context.Set<Comment>().AddAsync(item);
        }

        async public Task<Comment> Get(Comment item)
        {
            return await _context.Set<Comment>().FindAsync(item);
        }

        public void Remove(Comment item)
        {
            _context.Set<Comment>().Remove(item);
        }

        public void Update(Comment item)
        {
            _context.Set<Comment>().Update(item);
        }

        async public Task<IEnumerable<Comment>> GetAllByFilmId(int id)
        {
            return await _context.Set<Comment>().Where<Comment>(item => item.Film.Id == id).ToListAsync();
        }
    }
}
