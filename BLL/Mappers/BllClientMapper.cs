using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllClientMapper
    {
        public static DalClient ToDalClient(this ClientEntity client)
        {
            return new DalClient()
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Patronymic = client.Patronymic,
                Email = client.Email,
                Password = client.Password,
                Age = client.Age
            };
        }

        public static ClientEntity ToBllClient(this DalClient client)
        {
            return new ClientEntity()
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Patronymic = client.Patronymic,
                Email = client.Email,
                Password = client.Password,
                Age = client.Age
            };
        }
    }
}
