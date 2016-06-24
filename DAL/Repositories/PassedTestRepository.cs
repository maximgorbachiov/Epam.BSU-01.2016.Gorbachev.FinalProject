using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using DAL.Mappers;
using ORM;
using DAL.Entities;
using DAL.Interfaces.IRepositories;

namespace DAL.Repositories
{
    public class PassedTestRepository : EntityRepository, IPassedTestRepository
    {
        public PassedTestRepository(DbContext context) : base(context) { }

        public IEnumerable<DalPassedTest> GetAllPassedTests()
        {
            var passedTests = context.Set<PassedTest>().ToList();
            return passedTests.Select(passedTest => passedTest.ToDalPassedTest());
        }

        public DalPassedTest GetPassedTestById(int id)
        {
            return context.Set<PassedTest>().FirstOrDefault(passedTest => passedTest.Id == id).ToDalPassedTest();
        }

        public IEnumerable<DalPassedTest> GetPassedTestByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalPassedTest> GetPassedTestByPredicate(Expression<Func<DalPassedTest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalPassedTest> GetPassedTestsByTestId(int testId)
        {
            var tests = context.Set<PassedTest>().Where(test => test.TestId == testId).ToList();
            return tests.Select(test => test.ToDalPassedTest());
        }

        public IEnumerable<DalPassedTest> GetPassedTestsByClientId(int clientId)
        {
            var tests = context.Set<PassedTest>().Where(test => test.ClientId == clientId).ToList();
            return tests.Select(test => test.ToDalPassedTest());
        }

        public IEnumerable<DalPassedTest> GetPassedTestsByCategoryAndClientId(int categoryId, int clientId)
        {
            var passedTests = context.Set<PassedTest>().Where(test => test.ClientId == clientId).ToList();
            var tests = context.Set<Test>().Where(test => test.CategoryId == categoryId).ToList();

            var result = tests.Select(test => passedTests
                .SingleOrDefault(passedTest => test.Id == passedTest.TestId))
                .Where(current => current != null)
                .Select(passedTest => passedTest.ToDalPassedTest());

            return result;
        }

        public void CreatePassedTest(DalPassedTest passedTest)
        {
            context.Set<PassedTest>().Add(passedTest.ToPassedTest());
        }

        public void RemovePassedTest(int id)
        {
            var test = context.Set<PassedTest>().FirstOrDefault(t => t.Id == id);

            if (test == null) return;

            context.Set<PassedTest>().Remove(test);
        }

        public void UpdatePassedTest(DalPassedTest dalPassedTest)
        {
            var ormPassedTest = context.Set<PassedTest>().FirstOrDefault(test => test.Id == dalPassedTest.Id);

            if (ormPassedTest == null) return;

            ormPassedTest.TestId = dalPassedTest.TestId;
            ormPassedTest.ClientId = dalPassedTest.ClientId;
            ormPassedTest.CountOfRightAnswer = dalPassedTest.CountOfRightAnswers;
            ormPassedTest.TimeToPass = dalPassedTest.TimeToPass;
            ormPassedTest.DateOfPass = dalPassedTest.DateOfPass;
            context.Entry(ormPassedTest).State = EntityState.Modified;
        }
    }
}
