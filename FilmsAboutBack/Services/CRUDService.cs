using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CRUDService<TRepository, TEntity> : ICRUDService<TEntity>
    {
        private ICRUDRepository<TEntity> _repository;

        public CRUDService(ICRUDRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<TEntity> CreateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        async public Task<TEntity> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public Task<TEntity> RemoveAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
