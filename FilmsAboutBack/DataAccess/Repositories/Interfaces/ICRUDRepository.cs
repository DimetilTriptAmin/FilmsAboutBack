using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.Interfaces
{
    public interface ICRUDRepository<TEntity>
    {
        Task<TEntity> Get(TEntity item);
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
