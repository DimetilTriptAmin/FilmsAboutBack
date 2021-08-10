using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface ICommentService
    {
        Task<GenericResponse<IEnumerable<CommentResponse>>> GetAllByFilmIdAsync(int id);
        Task<GenericResponse<CommentResponse>> CreateCommentAsync(int userId, int filmId, string text);
        Task<GenericResponse<int>> DeleteCommentAsync(int id);

    }
}
