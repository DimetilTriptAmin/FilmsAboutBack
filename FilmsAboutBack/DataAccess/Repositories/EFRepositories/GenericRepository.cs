using FilmsAboutBack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsAboutBack.DataAccess.Repositories.EFRepositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            await _context.Set<TEntity>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task RemoveAsync(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            var items = _context.Set<TEntity>().AsQueryable();
            return await items.Where(predicate).ToListAsync();
        }
    }
}
