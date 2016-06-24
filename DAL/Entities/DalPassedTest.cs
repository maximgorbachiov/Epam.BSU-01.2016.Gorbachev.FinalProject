using System;
using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalPassedTest : IEntity
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int ClientId { get; set; }
        public int CountOfRightAnswers { get; set; }
        public TimeSpan? TimeToPass { get; set; }
        public DateTime? DateOfPass { get; set; }
    }
}
