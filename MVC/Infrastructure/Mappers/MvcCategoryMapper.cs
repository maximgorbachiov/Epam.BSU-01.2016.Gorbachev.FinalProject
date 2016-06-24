using MVC.Models.Shared;
using BLL.Entities;

namespace MVC.Infrastructure.Mappers
{
    public static class MvcCategoryMapper
    {
        public static CategoryViewModel ToMvcCategory(this CategoryEntity categoryEntity)
        {
            return new CategoryViewModel()
            {
                Id = categoryEntity.Id,
                CategoryName = categoryEntity.CategoryName,
                //Role = (Role)userEntity.RoleId
            };
        }

        public static CategoryEntity ToBllCategory(this CategoryViewModel categoryViewModel)
        {
            return new CategoryEntity()
            {
                Id = categoryViewModel.Id,
                CategoryName = categoryViewModel.CategoryName,
                //RoleId = (int)userViewModel.Role
            };
        }
    }
}