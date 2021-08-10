using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using System.Linq;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CommentService : ServiceBase, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<GenericResponse<IEnumerable<CommentResponse>>> GetAllByFilmIdAsync(int id)
        {
            try
            {
                var comments = await _unitOfWork.CommentRepository.Filter(c => c.FilmId == id);
                var ratings = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == id);
                var users = await _unitOfWork.UserRepository.GetAllAsync();

                var commentsJoinRatingsJoinUsers = comments
                    .Join(ratings, comment => comment.UserId, rating => rating.UserId,
                          (comment, rating) => new
                          {
                              UserId = comment.UserId,
                              Text = comment.Text,
                              PublishDate = comment.PublishDate,
                              Rating = rating.Rate,
                          })
                    .Join(users, rnc => rnc.UserId, user => user.Id,
                          (rnc, user) => new CommentResponse(user.UserName, user.Avatar, rnc.Text, rnc.Rating, rnc.PublishDate))
                    .ToList();
                return new GenericResponse<IEnumerable<CommentResponse>>(commentsJoinRatingsJoinUsers);
            }
            catch
            {
                return new GenericResponse<IEnumerable<CommentResponse>>("$3rv3r 1s d3ad.");
            }
        }
    }
}
