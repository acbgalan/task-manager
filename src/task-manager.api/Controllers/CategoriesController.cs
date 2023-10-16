using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.api.Requests.Category;
using task_manager.api.Responses.Category;
using task_manager.data.Models;
using task_manager.data.Repositories;
using task_manager.data.Repositories.Interface;

namespace task_manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            var categoryResponse = _mapper.Map<CategoryResponse>(category);

            return Ok(categoryResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesResponse = _mapper.Map<List<CategoryResponse>>(categories);

            return Ok(categoriesResponse);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            if (createCategoryRequest == null)
            {
                return BadRequest();
            }

            var category = _mapper.Map<Category>(createCategoryRequest);
            await _categoryRepository.AddAsync(category);
            int saveResult = await _categoryRepository.SaveSync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var categoryResponse = _mapper.Map<CategoryResponse>(category);

            return CreatedAtAction("GetCategory", new { id = categoryResponse.Id }, categoryResponse);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            bool exits = await _categoryRepository.ExitsAsync(id);

            if (!exits)
            {
                return NotFound();
            }

            category.Id = id;
            await _categoryRepository.UpdateAsync(category);
            int saveResult = await _categoryRepository.SaveSync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected value when updating a record.");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            bool exits = await _categoryRepository.ExitsAsync(id);

            if (!exits)
            {
                return NotFound("Category not found");
            }

            await _categoryRepository.DeleteAsync(id);
            int saveResult = await _categoryRepository.SaveSync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected value when deleting a record.");
            }

            return NoContent();
        }

    }
}
