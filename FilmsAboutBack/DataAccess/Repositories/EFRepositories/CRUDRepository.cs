using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    //TODO: add try/catch
    public class CRUDRepository<TEntity> : ICRUDRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;

        public CRUDRepository(DbContext context)
        {
            _context = context;
        }

        async public Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        async public Task<TEntity> CreateAsync(TEntity item)
        {
            await _context.Set<TEntity>().AddAsync(item);
            return item;
        }

        async public Task<TEntity> RemoveAsync(int id)
        {
            TEntity item = GetAsync(id).Result;
            await Task.Run(() => _context.Set<TEntity>().Remove(item));
            return item;
        }

        async public Task<TEntity> UpdateAsync(TEntity item)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(item));
            return item;
        }
    }
}
