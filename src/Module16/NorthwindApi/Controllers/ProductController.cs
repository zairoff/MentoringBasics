using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;
using NorthwindApi.Repository;
using System;
using System.Threading.Tasks;

namespace NorthwindApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IRepository<Product> repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.FindAsync(c => c.ProductID == id);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                var existedProduct = await _repository.FindAsync(c => c.ProductName.Equals(product.ProductName));

                if (existedProduct != null)
                {
                    return Conflict($"{product.ProductName} already exist");
                }

                await _repository.AddAsync(product);

                return CreatedAtAction(nameof(Get), new { id = product.ProductID }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(ProductController));
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            try
            {
                var existedProduct = await _repository.FindAsync(c => c.ProductID == id);

                if (existedProduct == null)
                {
                    return NotFound();
                }

                await _repository.Update(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(ProductController));
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReport(int id)
        {
            try
            {
                var product = await _repository.FindAsync(c => c.ProductID == id);

                if (product == null)
                {
                    return NotFound();
                }

                await _repository.Delete(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(ProductController));
                return StatusCode(500);
            }
        }
    }
}
