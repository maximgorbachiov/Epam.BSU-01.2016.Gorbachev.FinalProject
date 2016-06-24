using MVC.Models.Shared;
using BLL.Entities;

namespace MVC.Infrastructure.Mappers
{
    public static class MvcTestMapper
    {
        public static TestViewModel ToMvcTest(this TestEntity testEntity)
        {
            return new TestViewModel()
            {
                Id = testEntity.Id,
                TestName = testEntity.TestName,
                CategoryId = testEntity.CategoryId,
                DateOfCreation = testEntity.DateOfCreation
            };
        }

        public static TestEntity ToBllTest(this TestViewModel testViewModel)
        {
            return new TestEntity()
            {
                Id = testViewModel.Id,
                TestName = testViewModel.TestName,
                CategoryId = testViewModel.CategoryId,
                DateOfCreation = testViewModel.DateOfCreation
            };
        }
    }
}