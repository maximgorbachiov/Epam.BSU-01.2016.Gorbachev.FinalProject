using System;

namespace BLL.Entities
{
    public class PassedTestEntity
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int ClientId { get; set; }
        public int CountOfRightAnswers { get; set; }
        public TimeSpan? TimeToPass { get; set; }
        public DateTime? DateOfPass { get; set; }
    }
}
