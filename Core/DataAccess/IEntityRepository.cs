using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filters = null);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetSql(string sql);
    }
}
