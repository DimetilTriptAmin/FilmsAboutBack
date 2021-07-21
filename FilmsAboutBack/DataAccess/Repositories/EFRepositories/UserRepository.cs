using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepository
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        async public void Create(User item)
        {
            await _context.Set<User>().AddAsync(item);
        }

        async public Task<User> Get(User item)
        {
            return await _context.Set<User>().FindAsync(item.Id);
        }

        async public Task<User> GetById(string id)
        {
            return await _context.Set<User>().FindAsync(id);
        }

        public void Remove(User item)
        {
            _context.Set<User>().Remove(item);
        }

        public void Update(User item)
        {
            _context.Set<User>().Update(item);
        }
    }
}
