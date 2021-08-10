using System;
using System.Threading.Tasks;
using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Models;

namespace FilmsAboutBack.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        public IGenericRepository<User> UserRepository { get; }
        public IGenericRepository<Film> FilmRepository { get; }
        public IGenericRepository<Comment> CommentRepository { get; }
        public IGenericRepository<Rating> RatingRepository { get; }
        public Task<int> SaveAsync();
    }
}
