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

        public async Task<IEnumerable<CommentResponse>> GetAllByFilmIdAsync(int id)
        {
            var comments = await _unitOfWork.CommentRepository.Filter(c => c.FilmId == id);
            var ratings = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == id);
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            var commentsJoinRatings = comments
                .Join(ratings, comment => comment.UserId, rating => rating.UserId,
                      (comment, rating) => new {
                          UserId = comment.UserId,
                          Text = comment.Text,
                          PublishDate = comment.PublishDate,
                          Rating = rating.Rate,
                      })
                .Join(users, tbl => tbl.UserId, user => user.Id,
                      (tbl, user) => new CommentResponse()
                      {
                          Avatar = user.Avatar,
                          UserName = user.UserName,
                          Rating = tbl.Rating,
                          Text = tbl.Text,
                          PublishDate = tbl.PublishDate,
                      }).ToList();
            return commentsJoinRatings;
        }
    }
}
