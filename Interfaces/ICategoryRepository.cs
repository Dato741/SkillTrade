using SkillTrade.Dtos.Create;
using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategoriesAsync(int pageNumber, int pageSize);
        public Task<Category?> GetCategoryAsync(int cateogryId);
        public Task<Category> CreateCategoryAsync(Category category);
        public Task DeleteCategoryAsync(int cateogryId);
    }
}
