using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CommentService : ServiceBase, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<GenericResponse<CommentResponse>> CreateCommentAsync(int userId, int filmId, string text)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetAsync(userId);

                if(user == null)
                {
                    return new GenericResponse<CommentResponse>("User not found.");
                }

                Comment comment = new Comment(userId, filmId, text, DateTime.Now);

                await _unitOfWork.CommentRepository.CreateAsync(comment);
                await _unitOfWork.SaveAsync();

                var ratingRequest = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == filmId && r.UserId == userId);
                var rating = ratingRequest.FirstOrDefault();
                var rate = rating == null ? 0 : rating.Rate;

                return new GenericResponse<CommentResponse>(
                    new CommentResponse(comment.Id, user.UserName, user.Avatar, text, rate, comment.PublishDate)
                    );
            }
            catch
            {
                return new GenericResponse<CommentResponse>("Internal server error.");
            }
        }

        public async Task<GenericResponse<int>> DeleteCommentAsync(int id)
        {
            try
            {
                var comment = await _unitOfWork.CommentRepository.GetAsync(id);

                if(comment == null)
                {
                    return new GenericResponse<int>("Comment not found.");
                }

                await _unitOfWork.CommentRepository.RemoveAsync(comment);
                await _unitOfWork.SaveAsync();

                return new GenericResponse<int>(id);
            }
            catch
            {
                return new GenericResponse<int>("Internal server error.");
            }
        }

        public async Task<GenericResponse<IEnumerable<CommentResponse>>> GetAllByFilmIdAsync(int id)
        {
            try
            {
                var comments = await _unitOfWork.CommentRepository.Filter(c => c.FilmId == id);
                var ratings = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == id);
                var users = await _unitOfWork.UserRepository.GetAllAsync();

                var commentsJoinRatings = comments
                    .Join(ratings, comment => comment.UserId, rating => rating.UserId,
                          (comment, rating) => new
                          {
                              CommentId = comment.Id,
                              UserId = comment.UserId,
                              Text = comment.Text,
                              PublishDate = comment.PublishDate,
                              Rating = rating.Rate,
                          })
                    .Join(users, cnr => cnr.UserId, user => user.Id,
                          (cnr, user) => 
                          new CommentResponse(cnr.CommentId, user.UserName, user.Avatar, cnr.Text, cnr.Rating, cnr.PublishDate))
                    .ToList();
                return new GenericResponse<IEnumerable<CommentResponse>>(commentsJoinRatings);
            }
            catch
            {
                return new GenericResponse<IEnumerable<CommentResponse>>("Internal server error.");
            }
        }
    }
}
