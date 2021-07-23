using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CommentService : CRUDService<Comment>, ICommentService
    {
        private IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork.CommentRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> GetAllByFilmIdAsync(int id)
        {
             return await _unitOfWork.CommentRepository.GetAllByFilmIdAsync(id);
        }
    }
}
