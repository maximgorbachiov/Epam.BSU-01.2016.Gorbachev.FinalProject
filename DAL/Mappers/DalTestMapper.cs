using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalTestMapper
    {
        public static Test ToTest(this DalTest test)
        {
            return new Test()
            {
                Id = test.Id,
                Name = test.TestName,
                CategoryId = test.CategoryId,
                DateOfCreate = test.DateOfCreation                
            };
        }

        public static DalTest ToDalTest(this Test test)
        {
            return new DalTest()
            {
                Id = test.Id,
                TestName = test.Name,
                CategoryId = test.CategoryId,
                DateOfCreation = test.DateOfCreate
            };
        }
    }
}
