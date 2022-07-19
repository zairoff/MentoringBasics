using Microsoft.EntityFrameworkCore;
using ORM.Model;

namespace ORM.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = "Server=(localdb)\\mssqllocaldb;Database=ORM.NET;Trusted_Connection=True;MultipleActiveResultSets=true";
            options.UseSqlServer(connection);
        }


    }
}
