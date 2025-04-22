using SkillTrade.Dtos.Create;
using SkillTrade.Entities;

namespace SkillTrade.Mapping
{
    public static class CategoryMapping
    {
        public static Category ToCategoryEntity(this CreateCategoryDto category)
        {
            return new Category
            {
                Name = category.CategoryName
            };
        }
    }
}
