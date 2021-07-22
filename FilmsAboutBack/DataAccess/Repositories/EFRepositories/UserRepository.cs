using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : CRUDRepository<User>, IUserRepository
    { 
        public UserRepository(DbContext context) : base (context)
        {
        }
    }
}
