using ADO.NET.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADO.NET
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveAllAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
