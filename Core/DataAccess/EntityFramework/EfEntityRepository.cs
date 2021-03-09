using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppointmentManagement.Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _dbSet;
        //protected virtual DbSet<TEntity> Entities => _dbSet ?? (_dbSet = _context.Set<TEntity>());
        public EfEntityRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filters = null)
        {


            return filters == null
                       ? await _dbSet.ToListAsync()
                       : await _dbSet.Where(filters).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetSql(string sql)
        {
            return _dbSet.FromSqlRaw(sql).AsNoTracking();
        }
    }
}