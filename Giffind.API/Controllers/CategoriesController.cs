using AutoMapper;
using GifFind.API.Entities;
using GifFind.API.Models.DTO;
using GifFind.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifFind.API.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(Guid userId)
        {
            var categories = await _categoryService.GetCategoriesAsync(userId);

            if (categories == null || categories.Count().Equals(default))
            {
                return NoContent();
            }

            var mappedCategories = _mapper.Map<IEnumerable<CategoryForGet>>(categories);

            return Ok(mappedCategories);

        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var mappedCategory = _mapper.Map<CategoryForGet>(category);

            return Ok(mappedCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryForCreate category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryMapped = _mapper.Map<Category>(category);

            var newCategory = await _categoryService.CreateCategoryAsync(categoryMapped);

            var mappedCategory = _mapper.Map<CategoryForGet>(newCategory);

            return Created("", mappedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var categoryRemoved = await _categoryService.DeleteCategoryAsync(id);

            return NoContent();
        }
    }
}
