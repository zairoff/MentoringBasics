using ADO.NET.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ADO.NET.Test
{
    public class OrderRepositoryTests
    {
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;

        public OrderRepositoryTests()
        {
            _orderRepository = new OrderRepository("Server=(localdb)\\mssqllocaldb; database=ADONET; Trusted_Connection=True;MultipleActiveResultSets=true");
            _productRepository = new ProductRepository("Server=(localdb)\\mssqllocaldb; database=ADONET; Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        [Fact]
        public async Task CreateOrder()
        {
            var product = new Product
            {
                Id = 2,
                Name = "NoteBook",
                Description = "Brand new",
                Height = 1.2M,
                Length = 0.4M,
                Weight = 1.1M,
                Width = 1.5M
            };

            var order = new Order
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                ProductId = product.Id,
                Status = "Added"
            };

            await _productRepository.RemoveAllAsync();
            await _productRepository.AddAsync(product);
            await _orderRepository.AddAsync(order);

            var result = await _orderRepository.GetAsync(1);

            Assert.NotNull(result);
            Assert.True(result.Id == order.Id);
            Assert.True(result.ProductId == product.Id);
        }
    }
}
