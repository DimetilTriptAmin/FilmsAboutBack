using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CommentService : CRUDService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CommentRepository)
        {
        }

        public async Task<IEnumerable<Comment>> GetAllByFilmIdAsync(int id)
        {
            return await _unitOfWork.CommentRepository.GetAllByFilmIdAsync(id);
        }
    }
}
