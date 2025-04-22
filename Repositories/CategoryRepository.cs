using Microsoft.EntityFrameworkCore;
using SkillTrade.Data;
using SkillTrade.Dtos.Create;
using SkillTrade.Entities;
using SkillTrade.Interfaces;

namespace SkillTrade.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SkillTradeDbContext _context;
        public CategoryRepository(SkillTradeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync(int pageNumber, int pageSize)
        {
            List<Category> categories = await _context.Categories
                                                            .Skip((pageNumber - 1) * pageSize)
                                                            .Take(pageSize)
                                                            .ToListAsync();

            return categories;
        }

        public async Task<Category?> GetCategoryAsync(int cateogryId)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == cateogryId);

            return category;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategoryAsync(int cateogryId)
        {
            await _context.Categories.Where(c => c.Id == cateogryId).ExecuteDeleteAsync();
        }
    }
}
