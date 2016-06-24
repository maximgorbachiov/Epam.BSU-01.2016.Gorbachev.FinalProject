using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
