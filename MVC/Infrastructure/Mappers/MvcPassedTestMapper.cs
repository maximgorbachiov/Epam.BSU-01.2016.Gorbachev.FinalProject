using MVC.Models.Client;
using BLL.Entities;

namespace MVC.Infrastructure.Mappers
{
    public static class MvcPassedTestMapper
    {
        public static PassedTestViewModel ToMvcPassedTest(this PassedTestEntity passedTestEntity)
        {
            return new PassedTestViewModel()
            {
                Id = passedTestEntity.Id,
                ClientId = passedTestEntity.ClientId,
                TestId = passedTestEntity.TestId,
                CountOfRightResults = passedTestEntity.CountOfRightAnswers,
                TimeToPass = passedTestEntity.TimeToPass,
                DateOfPass = passedTestEntity.DateOfPass
            };
        }

        public static PassedTestEntity ToBllPassedTest(this PassedTestViewModel passedTestEntity)
        {
            return new PassedTestEntity()
            {
                Id = passedTestEntity.Id,
                ClientId = passedTestEntity.ClientId,
                TestId = passedTestEntity.TestId,
                CountOfRightAnswers = passedTestEntity.CountOfRightResults,
                TimeToPass = passedTestEntity.TimeToPass,
                DateOfPass = passedTestEntity.DateOfPass
            };
        }
    }
}