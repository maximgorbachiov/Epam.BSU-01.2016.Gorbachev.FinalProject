using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Mappers;
using System;

namespace BLL.Services
{
    public class CategoryService : EntityService, ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow) { }

        public CategoryEntity GetCategoryEntity(int id)
        {
            return uow.Categories.GetCategoryById(id).ToBllCategory();
        }

        public IEnumerable<CategoryEntity> GetCategoriesByName(string name)
        {
            return uow.Categories.GetCategoryByName(name).Select(dalCategory => dalCategory.ToBllCategory());
        }

        public IEnumerable<CategoryEntity> GetAllCategoryEntities()
        {
            var temp = uow.Categories.GetAllCategories().Select(dalCategory => dalCategory.ToBllCategory());
            return temp;
        }

        public void CreateCategory(CategoryEntity category)
        {
            uow.Categories.CreateCategory(category.ToDalCategory());
            uow.Commit();
        }

        public void UpdateCategory(CategoryEntity category)
        {
            uow.Categories.UpdateCategory(category.ToDalCategory());
            uow.Commit();
        }

        public void DeleteCategory(CategoryEntity category)
        {
            uow.Categories.RemoveCategory(category.Id);
            uow.Commit();
        }

        public bool IsCategoryWithNameExist(string name)
        {
            List<CategoryEntity> categories = uow.Categories.GetCategoryByName(name)
                .Select(category => category.ToBllCategory()).ToList();

            foreach (var category in categories)
            {
                if (category.CategoryName == name) return true;
            }

            return false;
        }
    }
}
