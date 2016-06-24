using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllTestMapper
    {
        public static DalTest ToDalTest(this TestEntity test)
        {
            return new DalTest()
            {
                Id = test.Id,
                TestName = test.TestName,
                CategoryId = test.CategoryId,
                DateOfCreation = test.DateOfCreation
            };
        }

        public static TestEntity ToBllTest(this DalTest test)
        {
            return new TestEntity()
            {
                Id = test.Id,
                TestName = test.TestName,
                CategoryId = test.CategoryId,
                DateOfCreation = test.DateOfCreation
            };
        }
    }
}
