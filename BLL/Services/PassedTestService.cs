using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Mappers;

namespace BLL.Services
{
    public class PassedTestService : EntityService, IPassedTestService
    {
        public PassedTestService(IUnitOfWork uow) : base(uow) { }

        public PassedTestEntity GetPassedTestEntity(int id)
        {
            return uow.PassedTests.GetPassedTestById(id).ToBllPassedTest();
        }

        public IEnumerable<PassedTestEntity> GetAllPassedTestEntities()
        {
            return uow.PassedTests.GetAllPassedTests().Select(dalPassedTest => dalPassedTest.ToBllPassedTest());
        }

        public IEnumerable<PassedTestEntity> GetPassedTestsByClientId(int clientId)
        {
            return uow.PassedTests.GetPassedTestsByClientId(clientId)
                .Select(dalPassedTest => dalPassedTest.ToBllPassedTest());
        }

        public IEnumerable<PassedTestEntity> GetPassedTestsByTestId(int testId)
        {
            return uow.PassedTests.GetPassedTestsByTestId(testId)
                .Select(dalPassedTest => dalPassedTest.ToBllPassedTest());
        }

        public IEnumerable<PassedTestEntity> GetPassedTestByCategoryAndClientId(int categoryId, int clientId)
        {
            return uow.PassedTests.GetPassedTestsByCategoryAndClientId(categoryId, clientId)
                .Select(dalPassedTest => dalPassedTest.ToBllPassedTest());
        }

        public IEnumerable<PassedTestEntity> GetPassedTestBySearchingToken(string token, int clientId)
        {
            var tests = uow.Tests.GetTestsBySearchingToken(token).ToList();
            var passedTests = uow.PassedTests.GetPassedTestsByClientId(clientId).ToList();

            return tests.Select(test => passedTests
                .SingleOrDefault(passedTest => test.Id == passedTest.TestId))
                .Where(current => current != null)
                .Select(passedTest => passedTest.ToBllPassedTest());
        }

        public void CreatePassedTestEntity(PassedTestEntity passedTest)
        {
            uow.PassedTests.CreatePassedTest(passedTest.ToDalPassedTest());
            uow.Commit();
        }

        public void DeletePassedTestEntity(PassedTestEntity passedTest)
        {
            uow.PassedTests.RemovePassedTest(passedTest.ToDalPassedTest().Id);
            uow.Commit();
        }

        public void UpdatePassedTestEntity(PassedTestEntity passedTest)
        {
            uow.PassedTests.UpdatePassedTest(passedTest.ToDalPassedTest());
            uow.Commit();
        }
    }
}
