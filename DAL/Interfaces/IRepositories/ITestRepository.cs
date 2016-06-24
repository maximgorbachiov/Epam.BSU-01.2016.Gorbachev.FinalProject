using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface ITestRepository
    {
        void CreateTest(DalTest test);
        DalTest GetTestById(int id);
        IEnumerable<DalTest> GetTestByPredicate(Expression<Func<DalTest, bool>> predicate);
        IEnumerable<DalTest> GetTestByName(string name);
        IEnumerable<DalTest> GetAllTests();
        IEnumerable<DalTest> GetTestsByCategoryId(int categoryId);
        IEnumerable<DalTest> GetTestsBySearchingToken(string token);
        IEnumerable<DalTest> GetTestsByDate(DateTime? dateOfCreation);
        void UpdateTest(DalTest test);
        void RemoveTest(int id);
    }
}
