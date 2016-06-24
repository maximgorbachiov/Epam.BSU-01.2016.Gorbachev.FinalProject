using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Client
{
    public class ResultViewModel
    {
        public ResultViewModel()
        {
            WrongResults = new List<int>();
        }

        [Display(Name = "Count of right answers")]
        public int CountOfRightAnswers { get; set; }

        [Display(Name = "Time to pass")]
        public TimeSpan? TimeToPass { get; set; }

        [Display(Name = "Wrong results : ")]
        public List<int> WrongResults { get; set; }
    }
}