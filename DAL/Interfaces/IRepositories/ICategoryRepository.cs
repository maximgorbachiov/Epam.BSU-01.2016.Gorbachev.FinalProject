using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface ICategoryRepository
    {
        void CreateCategory(DalCategory category);
        DalCategory GetCategoryById(int id);
        IEnumerable<DalCategory> GetCategoryByPredicate(Expression<Func<DalCategory, bool>> predicate);
        IEnumerable<DalCategory> GetCategoryByName(string name);
        IEnumerable<DalCategory> GetAllCategories();
        void UpdateCategory(DalCategory category);
        void RemoveCategory(int id);
    }
}
