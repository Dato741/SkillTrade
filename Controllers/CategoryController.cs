using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrade.Dtos.Create;
using SkillTrade.Entities;
using SkillTrade.Interfaces;
using SkillTrade.Mapping;

namespace SkillTrade.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCategories(int pageNumber = 1, int pageSize = 10)
        {
            List<Category> categories = await _categoryRepo.GetAllCategoriesAsync(pageNumber, pageSize);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            Category? category = await _categoryRepo.GetCategoryAsync(categoryId);

            if (category == null) return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            Category category = createCategoryDto.ToCategoryEntity();

            await _categoryRepo.CreateCategoryAsync(category);

            return CreatedAtAction(nameof(GetCategoryById), new {categoryid = category.Id}, category);
        }

        [HttpDelete("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryRepo.DeleteCategoryAsync(categoryId);

            return NoContent();
        }
    }
}
