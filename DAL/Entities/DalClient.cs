using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalClient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
