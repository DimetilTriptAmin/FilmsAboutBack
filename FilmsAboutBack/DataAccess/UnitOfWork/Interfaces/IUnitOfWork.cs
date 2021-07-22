using System;
using System.Threading.Tasks;
using FilmsAboutBack.DataAccess.Repositories.Interfaces;

namespace FilmsAboutBack.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        public IUserRepository UserRepository { get; }
        public IFilmRepository FilmRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IRatingRepository RatingRepository { get; }
        public Task<int> SaveAsync();
    }
}
