using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalPassedTestMapper
    {
        public static PassedTest ToPassedTest(this DalPassedTest passedTest)
        {
            return new PassedTest()
            {
                Id = passedTest.Id,
                TestId = passedTest.TestId,
                ClientId = passedTest.ClientId,
                CountOfRightAnswer = passedTest.CountOfRightAnswers,
                TimeToPass = passedTest.TimeToPass,
                DateOfPass = passedTest.DateOfPass
            };
        }

        public static DalPassedTest ToDalPassedTest(this PassedTest passedTest)
        {
            return new DalPassedTest()
            {
                Id = passedTest.Id,
                TestId = passedTest.TestId,
                ClientId = passedTest.ClientId,
                CountOfRightAnswers = passedTest.CountOfRightAnswer,
                TimeToPass = passedTest.TimeToPass,
                DateOfPass = passedTest.DateOfPass
            };
        }
    }
}
