using System;

namespace BLL.Entities
{
    public class TestEntity
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DateOfCreation { get; set; } 
    }
}
