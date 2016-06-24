using MVC.Models;
using BLL.Entities;

namespace MVC.Infrastructure.Mappers
{
    public static class MvcRegisterMapper
    {
        public static RegisterViewModel ToMvcRegisterClient(this ClientEntity clientEntity)
        {
            return new RegisterViewModel()
            {
                Id = clientEntity.Id,
                Name = clientEntity.Name,
                Surname = clientEntity.Surname,
                Patronymic = clientEntity.Patronymic,
                Email = clientEntity.Email,
                Password = clientEntity.Password,
                Age = clientEntity.Age
                //Role = (Role)userEntity.RoleId
            };
        }

        public static ClientEntity ToBllClient(this RegisterViewModel registerViewModel)
        {
            return new ClientEntity()
            {
                Id = registerViewModel.Id,
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Patronymic = registerViewModel.Patronymic,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                Age = registerViewModel.Age
                //RoleId = (int)userViewModel.Role
            };
        }
    }
}