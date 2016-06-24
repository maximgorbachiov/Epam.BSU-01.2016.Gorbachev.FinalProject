using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Client
{
    public class PassedTestViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int TestId { get; set; }
        public int CountOfRightResults { get; set; }
        public int CountOfQuestions { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? TimeToPass { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfPass { get; set; }
        public string TestName { get; set; }
    }
}