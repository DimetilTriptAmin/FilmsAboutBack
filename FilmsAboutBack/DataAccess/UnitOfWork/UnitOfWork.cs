using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FilmsAboutBack.DataAccess.Repositories.EFRepositories;

namespace FilmsAboutBack.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private IUserRepository _userRepository;
        private IFilmRepository _filmRepository;
        private ICommentRepository _commentRepository;
        private IRatingRepository _ratingRepository;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository 
        { 
            get { return _userRepository ??= new UserRepository(_dbContext); }
        }

        public IFilmRepository FilmRepository
        {
            get { return _filmRepository ??= new FilmRepository(_dbContext); }
        }

        public ICommentRepository CommentRepository
        {
            get { return _commentRepository ??= new CommentRepository(_dbContext); }
        }

        public IRatingRepository RatingRepository
        {
            get { return _ratingRepository ??= new RatingRepository(_dbContext); }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
