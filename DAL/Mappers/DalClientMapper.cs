using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalClientMapper
    {
        public static Client ToClient(this DalClient client)
        {
            return new Client()
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

        public static DalClient ToDalClient(this Client client)
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
    }
}
