using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CRUDService<TEntity> : ICRUDService<TEntity>
    {
        private ICRUDRepository<TEntity> _repository;

        public CRUDService(ICRUDRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> CreateAsync(TEntity item) => await _repository.CreateAsync(item);

        public async Task<TEntity> GetAsync(int id) => await _repository.GetAsync(id);

        public async Task<TEntity> RemoveAsync(int id) => await _repository.RemoveAsync(id);

        public async Task<TEntity> UpdateAsync(TEntity item) => await _repository.UpdateAsync(item);
    }
}
