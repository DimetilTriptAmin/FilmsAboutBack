using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;

namespace FilmsAboutBack.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UserRepository)
        {
        }
    }
}
