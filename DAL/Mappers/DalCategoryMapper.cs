using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalCategoryMapper
    {
        public static Category ToCategory(this DalCategory category)
        {
            return new Category()
            {
                Id = category.Id,
                Name = category.CategoryName
            };
        }

        public static DalCategory ToDalCategory(this Category category)
        {
            return new DalCategory()
            {
                Id = category.Id,
                CategoryName = category.Name
            };
        }
    }
}
