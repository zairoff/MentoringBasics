using ORM.Context;
using ORM.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ORM.Test
{
    public class OrderRepositoryTests
    {
        [Fact]
        public async Task Add_Get_Should_AddAndReturnOrder()
        {
            var product = new Product { Name = "Phone", Description = "Samsung" };
            

            using var context = new AppDbContext();
            var productRepo = new ProductRepository(context);
            var orderRepo = new OrderRepository(context);
            var unit = new UnitOfWork(context);

            await productRepo.AddAsync(product);
            await unit.SaveAsync();

            var order = new Order
            {
                ProductId = product.Id,
                Status = "Ordered",
                CreatedDate = DateTime.Now
            };

            await orderRepo.AddAsync(order);
            await unit.SaveAsync();

            var result = await orderRepo.GetAsync(order.Id);

            Assert.NotNull(result);
            Assert.Equal(result.Status, order.Status);
        }
    }
}
