using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    // TODO add saveChanges method
    public interface ICRUDService<TEntity>
    {
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task<TEntity> RemoveAsync(int id);
    }
}
