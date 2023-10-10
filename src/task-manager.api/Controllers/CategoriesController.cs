using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.data.Models;
using task_manager.data.Repositories.Interface;

namespace task_manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }

            Category category = new Category { Name = name };
            await _categoryRepository.AddAsync(category);
            int saveResult = await _categoryRepository.SaveSync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }



    }
}
