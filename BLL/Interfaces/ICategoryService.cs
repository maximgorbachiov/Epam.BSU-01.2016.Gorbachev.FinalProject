using System.Collections.Generic;
using BLL.Entities;


namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        CategoryEntity GetCategoryEntity(int id);
        IEnumerable<CategoryEntity> GetCategoriesByName(string name);
        IEnumerable<CategoryEntity> GetAllCategoryEntities();
        void CreateCategory(CategoryEntity category);
        void UpdateCategory(CategoryEntity category);
        void DeleteCategory(CategoryEntity category);
        bool IsCategoryWithNameExist(string name);
    }
}
