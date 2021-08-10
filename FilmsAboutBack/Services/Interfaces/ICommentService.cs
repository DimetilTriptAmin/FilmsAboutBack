using FilmsAboutBack.DataAccess.DTO.Respones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponse>> GetAllByFilmIdAsync(int id);
    }
}
