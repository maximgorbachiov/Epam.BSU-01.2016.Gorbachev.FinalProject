using System.Collections.Generic;
using System;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        TestEntity GetTestEntity(int id);
        IEnumerable<TestEntity> GetTestsByName(string name);
        IEnumerable<TestEntity> GetAllTestEntities();
        IEnumerable<TestEntity> GetTestsByCategoryId(int categoryId);
        IEnumerable<TestEntity> GetTestsBySearchingToken(string searchingToken);
        IEnumerable<TestEntity> GetTestsByDateOfCreation(DateTime? dateOfCreation);
        bool IsTestWithNameExist(string name);
        void CreateTest(TestEntity test);
        void UpdateTest(TestEntity test);
        void DeleteTest(TestEntity test);
    }
}
