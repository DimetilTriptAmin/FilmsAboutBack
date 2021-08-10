using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> UpdateAsync(TEntity item);
        Task RemoveAsync(TEntity item);
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
