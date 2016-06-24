using System;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class PassedTest
    {
        public int Id { get; set; }

        public TimeSpan? TimeToPass { get; set; }
        public DateTime? DateOfPass { get; set; }

        [Required]
        public int CountOfRightAnswer { get; set; }

        public int TestId { get; set; }
        public int ClientId { get; set; }

        public virtual Test Test { get; set; }
        public virtual Client Client { get; set; }
    }
}
