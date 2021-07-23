using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface ICRUDService<TEntity>
    {
        Task<TEntity> GetAsync(int id);
        Task CreateAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task RemoveAsync(int id);
    }
}
