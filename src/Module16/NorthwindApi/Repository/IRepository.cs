using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NorthwindApi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
    }
}
