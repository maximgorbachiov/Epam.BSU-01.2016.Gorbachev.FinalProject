using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ORM;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces.IRepositories;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class CategoryRepository : EntityRepository, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context) { }

        public void CreateCategory(DalCategory category)
        {
            context.Set<Category>().Add(category.ToCategory());
        }

        public DalCategory GetCategoryById(int id)
        {
            return context.Set<Category>().FirstOrDefault(category => category.Id == id).ToDalCategory();
        }

        public IEnumerable<DalCategory> GetCategoryByPredicate(Expression<Func<DalCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalCategory> GetCategoryByName(string name)
        {
            var categories = context.Set<Category>().ToList();
            return categories.Where(category => category.Name == name).Select(category => category.ToDalCategory());
        }

        public IEnumerable<DalCategory> GetAllCategories()
        {
            var categories = context.Set<Category>().ToList();
            return categories.Select(category => category.ToDalCategory());
        }

        public void UpdateCategory(DalCategory dalCategory)
        {
            var category = context.Set<Category>().FirstOrDefault(categ => categ.Id == dalCategory.Id);

            if (category == null) return;

            category.Name = dalCategory.CategoryName;
            context.Entry(category).State = EntityState.Modified;
        }

        public void RemoveCategory(int id)
        {
            var tests = context.Set<Test>().Where(test => test.CategoryId == id);
            var category = context.Set<Category>().FirstOrDefault(categ => categ.Id == id);

            foreach (var test in tests)
            {
                if (test == null) return;

                context.Set<Test>().Remove(test);
            }

            context.Set<Category>().Remove(category);
        }
    }
}
