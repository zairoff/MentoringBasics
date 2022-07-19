using Microsoft.EntityFrameworkCore;
using ORM.Context;
using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ORM
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;

        private DbSet<T> _dbSet;

        public DbSet<T> DbSet => _dbSet ??= _context.Set<T>();

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await DbSet.ToListAsync();
        }

        public void RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
