using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalCategory : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
