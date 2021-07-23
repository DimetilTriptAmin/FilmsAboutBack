using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Services.Interfaces;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services
{
    public class CRUDService<TEntity> : ICRUDService<TEntity>
    {

        protected IUnitOfWork _unitOfWork;
        private ICRUDRepository<TEntity> _repository;

        public CRUDService(IUnitOfWork unitOfWork, ICRUDRepository<TEntity> repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> GetAsync(int id) => await _repository.GetAsync(id);

        public async Task CreateAsync(TEntity item)
        {
            await _repository.CreateAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            await _repository.UpdateAsync(item);
            await _unitOfWork.SaveAsync();
        }
    }
}
