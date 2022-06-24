using ORM.Context;
using ORM.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ORM.Test
{
    public class OrderRepositoryTests
    {
        [Fact]
        public async Task Add_Get_Should_AddAndReturnOrder()
        {
            var products = new List<Product>()
            {
                new Product {  Name = "Test1", Description = "Test1" },
                new Product {  Name = "Test2", Description = "Test2" },
            };


            using var context = new AppDbContext();
            var orderRepo = new OrderRepository(context);
            var unit = new UnitOfWork(context);

            var order = new Order
            {
                Products = products,
                Status = "Waiting",
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
