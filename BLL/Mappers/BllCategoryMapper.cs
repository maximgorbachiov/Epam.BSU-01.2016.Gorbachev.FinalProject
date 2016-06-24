using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllCategoryMapper
    {
        public static DalCategory ToDalCategory(this CategoryEntity category)
        {
            return new DalCategory()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public static CategoryEntity ToBllCategory(this DalCategory category)
        {
            return new CategoryEntity()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }
    }
}
