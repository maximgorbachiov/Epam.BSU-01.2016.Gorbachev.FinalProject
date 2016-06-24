using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface IPassedTestRepository
    {
        void CreatePassedTest(DalPassedTest passedTest);
        DalPassedTest GetPassedTestById(int id);
        IEnumerable<DalPassedTest> GetPassedTestByPredicate(Expression<Func<DalPassedTest, bool>> predicate);
        IEnumerable<DalPassedTest> GetPassedTestByName(string name);
        IEnumerable<DalPassedTest> GetAllPassedTests();
        IEnumerable<DalPassedTest> GetPassedTestsByTestId(int testId);
        IEnumerable<DalPassedTest> GetPassedTestsByClientId(int clientId);
        IEnumerable<DalPassedTest> GetPassedTestsByCategoryAndClientId(int categoryId, int clientId);
        void UpdatePassedTest(DalPassedTest passedTest);
        void RemovePassedTest(int id);
    }
}
