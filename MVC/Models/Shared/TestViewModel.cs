using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.Models.Shared
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Test name field is empty")]
        [Display(Name = "Test title")]
        public string TestName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfCreation { get; set; }

        //[Required(ErrorMessage = "Category field is empty")]
        //[Display(Name = "Category title")]
        public int CategoryId { get; set; }

        //[Required(ErrorMessage = "Category field is empty")]
        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> Categories { get; set; }

        public QuestionViewModel CurrentQuestion { get; set; }

        //[Required(ErrorMessage = "You don't enter variant")]
        //[Display(Name = "Answers")]
        public List<QuestionViewModel> Questions { get; set; }
        //public Role Category { get; set; }
    }
}