using Xunit;
using System.Threading.Tasks;
using ADO.NET.Model;
using System.Linq;

namespace ADO.NET.Test
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository("Server=(localdb)\\mssqllocaldb; database=ADONET; Trusted_Connection=True;MultipleActiveResultSets=true"); 
        }

        [Fact]
        public async Task CreateProduct()
        {
            var product = new Product
            {
                Id= 1,
                Name = "NoteBook",
                Description = "Brand new",
                Height = 1.2M,
                Length = 0.4M,
                Weight = 1.1M,
                Width = 1.5M
            };

            await _productRepository.RemoveAllAsync();
            await _productRepository.AddAsync(product);

            var result = await _productRepository.GetAsync(1);

            Assert.NotNull(result);
            Assert.True(result.Id == product.Id);
        }

        [Fact]
        public async Task RemoveAllProduct()
        {
            var product = new Product
            {
                Id = 1,
                Name = "NoteBook",
                Description = "Brand new",
                Height = 1.2M,
                Length = 0.4M,
                Weight = 1.1M,
                Width = 1.5M
            };

            await _productRepository.RemoveAllAsync();
            await _productRepository.AddAsync(product);
            await _productRepository.RemoveAllAsync();

            var result = await _productRepository.GetAllAsync();

            Assert.NotNull(result);
            Assert.True(result.Count() == 0);
        }
    }
}
