using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using System.Linq;
using FilmsAboutBack.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmsAboutBack.Helpers;
using System.Net;
using FilmsAboutBack.Models;
using System;

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
                    return new GenericResponse<CommentResponse>("User not found.", HttpStatusCode.BadRequest);
                }

                Comment comment = new Comment()
                {
                    UserId = userId,
                    FilmId = filmId,
                    Text = text,
                    PublishDate = DateTime.Now,
                };

                await _unitOfWork.CommentRepository.CreateAsync(comment);
                await _unitOfWork.SaveAsync();

                var ratingRequest = await _unitOfWork.RatingRepository.Filter(r => r.FilmId == filmId && r.UserId == userId);
                var rating = ratingRequest.FirstOrDefault();

                CommentResponse commentResponse = new CommentResponse()
                {
                    Id = comment.Id,
                    Text = text,
                    UserName = user.UserName,
                    Avatar = user.Avatar,
                    PublishDate = comment.PublishDate,
                    Rating = rating == null ? 0 : rating.Rate,
                };

                return new GenericResponse<CommentResponse>(commentResponse, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<CommentResponse>("Internal server error.",
                                                                  HttpStatusCode.InternalServerError);
            }
        }

        public async Task<GenericResponse<int>> DeleteCommentAsync(int id)
        {
            try
            {
                var comment = await _unitOfWork.CommentRepository.GetAsync(id);

                if(comment == null)
                {
                    return new GenericResponse<int>("Comment not found.", HttpStatusCode.NotFound);
                }

                await _unitOfWork.CommentRepository.RemoveAsync(comment);
                await _unitOfWork.SaveAsync();

                return new GenericResponse<int>(id, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<int>("Internal server error.",
                                                                 HttpStatusCode.InternalServerError);
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
                    .Join(users, tbl => tbl.UserId, user => user.Id,
                          (tbl, user) => new CommentResponse()
                          {
                              Id = tbl.CommentId,
                              Avatar = user.Avatar,
                              UserName = user.UserName,
                              Rating = tbl.Rating,
                              Text = tbl.Text,
                              PublishDate = tbl.PublishDate,
                          }).ToList();
                return new GenericResponse<IEnumerable<CommentResponse>>(commentsJoinRatings, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<IEnumerable<CommentResponse>>("Internal server error.",
                                                                         HttpStatusCode.InternalServerError);
            }
        }
    }
}
