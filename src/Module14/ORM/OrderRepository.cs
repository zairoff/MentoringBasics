using Microsoft.EntityFrameworkCore;
using ORM.Context;
using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ORM
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Order>> GetAsync()
        {
            return await DbSet.Include(o => o.Product).ToListAsync();
        }

        public async override Task<IEnumerable<Order>> FindAsync(Expression<Func<Order, bool>> filter)
        {
            return await DbSet.Where(filter).Include(o => o.Product).ToListAsync();
        }

        public async override Task<Order> GetAsync(int id)
        {
            return await DbSet.Where(o => o.Id == id).Include(o => o.Product).FirstOrDefaultAsync();
        }
    }
}
