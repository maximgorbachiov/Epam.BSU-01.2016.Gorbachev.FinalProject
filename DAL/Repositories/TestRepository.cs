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
    public class TestRepository : EntityRepository, ITestRepository
    {
        public TestRepository(DbContext context) : base(context) { }

        public void CreateTest(DalTest test)
        {
            context.Set<Test>().Add(test.ToTest());
        }

        public DalTest GetTestById(int id)
        {
            return context.Set<Test>().FirstOrDefault(test => test.Id == id).ToDalTest();
        }

        public IEnumerable<DalTest> GetTestByPredicate(Expression<Func<DalTest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTest> GetTestByName(string name)
        {
            var tests = context.Set<Test>().ToList();
            return tests.Where(test => test.Name == name).Select(test => test.ToDalTest());
        }

        public IEnumerable<DalTest> GetAllTests()
        {
            var tests = context.Set<Test>().ToList();
            return tests.Select(test => test.ToDalTest());
        }

        public IEnumerable<DalTest> GetTestsByCategoryId(int categoryId)
        {
            var tests = context.Set<Test>().Where(test => test.CategoryId == categoryId).ToList();
            return tests.Select(test => test.ToDalTest());
        }

        public IEnumerable<DalTest> GetTestsBySearchingToken(string token)
        {
            var tests = context.Set<Test>().Where(test => test.Name.Contains(token)).ToList();
            return tests.Select(test => test.ToDalTest());
        }

        public IEnumerable<DalTest> GetTestsByDate(DateTime? dateOfCreation)
        {
            var tests = context.Set<Test>().Where(test => test.DateOfCreate == dateOfCreation).ToList();
            return tests.Select(test => test.ToDalTest());
        }

        public void RemoveTest(int id)
        {
            var test = context.Set<Test>().FirstOrDefault(t => t.Id == id);

            var questions = context.Set<Question>()?.Where(question => question.TestId == id).ToList();
            var passedTests = context.Set<PassedTest>()?.Where(passedTest => passedTest.TestId == id).ToList();

            if (questions == null) return;

            foreach (var question in questions)
            {
                if (question == null) return;

                var answers = context.Set<Answer>()?.Where(answer => answer.QuestionId == id).ToList();

                if (answers == null) return;

                foreach(var answer in answers)
                {
                    if (answer == null) return;

                    context.Set<Answer>().Remove(answer);
                }

                context.Set<Question>().Remove(question);
            }

            foreach (var passedTest in passedTests)
            {
                if (passedTest == null) return;

                context.Set<PassedTest>().Remove(passedTest);
            }

            context.Set<Test>().Remove(test);
        }

        public void UpdateTest(DalTest dalTest)
        {
            var ormTest = context.Set<Test>().FirstOrDefault(test => test.Id == dalTest.Id);
            
            if (ormTest == null)
            {
                return;
            }

            ormTest.Name = dalTest.TestName;
            ormTest.CategoryId = dalTest.CategoryId;
            context.Entry(ormTest).State = EntityState.Modified;
        }
    }
}
