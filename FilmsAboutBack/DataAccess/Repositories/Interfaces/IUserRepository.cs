using FilmsAboutBack.Models;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : ICRUDRepository<User>
    {
        Task<User> GetById(int id);
    }
}
