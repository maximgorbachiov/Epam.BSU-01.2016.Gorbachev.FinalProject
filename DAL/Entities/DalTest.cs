using System;
using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalTest : IEntity
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DateOfCreation { get; set; }
    }
}
