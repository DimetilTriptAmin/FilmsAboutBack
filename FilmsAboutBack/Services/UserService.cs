using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork.UserRepository)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
