using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FilmsAboutBack.DataAccess.Repositories.EFRepositories;
using FilmsAboutBack.Models;

namespace FilmsAboutBack.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Film> _filmRepository;
        private IGenericRepository<Comment> _commentRepository;
        private IGenericRepository<Rating> _ratingRepository;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<User> UserRepository 
        { 
            get { return _userRepository ??= new GenericRepository<User>(_dbContext); }
        }

        public IGenericRepository<Film> FilmRepository
        {
            get { return _filmRepository ??= new GenericRepository<Film>(_dbContext); }
        }

        public IGenericRepository<Comment> CommentRepository
        {
            get { return _commentRepository ??= new GenericRepository<Comment>(_dbContext); }
        }

        public IGenericRepository<Rating> RatingRepository
        {
            get { return _ratingRepository ??= new GenericRepository<Rating>(_dbContext); }
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
