using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Mappers;
using System;

namespace BLL.Services
{
    public class TestService : EntityService, ITestService
    {
        public TestService(IUnitOfWork uow) : base(uow) { }

        public TestEntity GetTestEntity(int id)
        {
            return uow.Tests.GetTestById(id).ToBllTest();
        }

        public IEnumerable<TestEntity> GetAllTestEntities()
        {
            return uow.Tests.GetAllTests().Select(dalTest => dalTest.ToBllTest());
        }

        public IEnumerable<TestEntity> GetTestsByName(string name)
        {
            return uow.Tests.GetTestByName(name).Select(dalTest => dalTest.ToBllTest());
        }

        public IEnumerable<TestEntity> GetTestsByCategoryId(int categoryId)
        {
            return uow.Tests.GetTestsByCategoryId(categoryId).Select(dalTest => dalTest.ToBllTest());
        }

        public IEnumerable<TestEntity> GetTestsBySearchingToken(string searchingToken)
        {
            return uow.Tests.GetTestsBySearchingToken(searchingToken).Select(dalTest => dalTest.ToBllTest());
        }

        public IEnumerable<TestEntity> GetTestsByDateOfCreation(DateTime? dateOfCreation)
        {
            return uow.Tests.GetTestsByDate(dateOfCreation).Select(dalTest => dalTest.ToBllTest());
        }

        public void CreateTest(TestEntity test)
        {
            uow.Tests.CreateTest(test.ToDalTest());
            uow.Commit();
        }

        public void DeleteTest(TestEntity test)
        {
            uow.Tests.RemoveTest(test.Id);
            uow.Commit();
        }

        public void UpdateTest(TestEntity test)
        {
            uow.Tests.UpdateTest(test.ToDalTest());
            uow.Commit();
        }

        public bool IsTestWithNameExist(string name)
        {
            IEnumerable<TestEntity> tests = uow.Tests.GetTestByName(name).Select(test => test.ToBllTest());

            foreach(var test in tests)
            {
                if (test.TestName == name) return true;
            }

            return false;
        }
    }
}
