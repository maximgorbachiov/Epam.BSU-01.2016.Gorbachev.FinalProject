using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IPassedTestService
    {
        PassedTestEntity GetPassedTestEntity(int id);
        IEnumerable<PassedTestEntity> GetAllPassedTestEntities();
        IEnumerable<PassedTestEntity> GetPassedTestsByClientId(int clientId);
        IEnumerable<PassedTestEntity> GetPassedTestsByTestId(int testId);
        IEnumerable<PassedTestEntity> GetPassedTestByCategoryAndClientId(int categoryId, int clientId);
        IEnumerable<PassedTestEntity> GetPassedTestBySearchingToken(string token, int clientId);
        void CreatePassedTestEntity(PassedTestEntity passedTest);
        void UpdatePassedTestEntity(PassedTestEntity passedTest);
        void DeletePassedTestEntity(PassedTestEntity passedTest);
    }
}
