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
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IRepository<Category> repository, ILogger<CategoryController> logger)
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
            var result = await _repository.FindAsync(c => c.CategoryID == id);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            try
            {
                var existedCategory = await _repository.FindAsync(c => c.CategoryName.Equals(category.CategoryName));

                if(existedCategory != null)
                {
                    return Conflict($"{category.CategoryName} already exist");
                }    

                await _repository.AddAsync(category);

                return CreatedAtAction(nameof(Get), new { id = category.CategoryID }, category);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, nameof(CategoryController));
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            try
            {
                var existedCategory = await _repository.FindAsync(c => c.CategoryID == id);

                if(existedCategory == null)
                {
                    return NotFound();
                }

                await _repository.Update(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(CategoryController));
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
                var category = await _repository.FindAsync(c => c.CategoryID == id);

                if (category == null)
                {
                    return NotFound();
                }

                await _repository.Delete(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(CategoryController));
                return StatusCode(500);
            }
        }
    }
}
