using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : CRUDRepository<User>, IUserRepository
    { 
        public UserRepository(DbContext context) : base (context)
        {
        }

        public async Task<User> GetUserByRefreshTokenAsync(string token) =>
            await _context.Set<User>().FirstOrDefaultAsync(u => u.refreshToken == token);
    }
}
