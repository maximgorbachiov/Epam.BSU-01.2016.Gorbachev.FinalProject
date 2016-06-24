using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllPassedTestMapper
    {
        public static DalPassedTest ToDalPassedTest(this PassedTestEntity passedTest)
        {
            return new DalPassedTest()
            {
                Id = passedTest.Id,
                TestId = passedTest.TestId,
                ClientId = passedTest.ClientId,
                CountOfRightAnswers = passedTest.CountOfRightAnswers,
                TimeToPass = passedTest.TimeToPass,
                DateOfPass = passedTest.DateOfPass
            };
        }

        public static PassedTestEntity ToBllPassedTest(this DalPassedTest passedTest)
        {
            return new PassedTestEntity()
            {
                Id = passedTest.Id,
                TestId = passedTest.TestId,
                ClientId = passedTest.ClientId,
                CountOfRightAnswers = passedTest.CountOfRightAnswers,
                TimeToPass = passedTest.TimeToPass,
                DateOfPass = passedTest.DateOfPass
            };
        }
    }
}
