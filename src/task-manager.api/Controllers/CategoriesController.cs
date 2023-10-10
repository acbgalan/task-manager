﻿using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            await _categoryRepository.AddAsync(category);
            int saveResult = await _categoryRepository.SaveSync();

            if (!(saveResult > 0))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected value when updating record.");
            }

            return NoContent();
        }






    }
}
