using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ORM
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void RemoveAsync(T entity);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
    }
}
