using ORM.Context;
using ORM.Model;
using System.Threading.Tasks;
using Xunit;

namespace ORM.Test
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task Add_Get_Should_AddAndReturnProduct()
        {
            var product = new Product
            {
                Name = "TV",
                Description = "Samsung"
            };

            using var context = new AppDbContext();
            var repo = new ProductRepository(context);
            var unit = new UnitOfWork(context);

            await repo.AddAsync(product);
            await unit.SaveAsync();

            var result = await repo.GetAsync(product.Id);

            Assert.NotNull(result);
            Assert.Equal(result.Name, product.Name);
        }
    }
}
