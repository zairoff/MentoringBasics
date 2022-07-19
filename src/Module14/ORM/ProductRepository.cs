using ORM.Context;
using ORM.Model;

namespace ORM
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
