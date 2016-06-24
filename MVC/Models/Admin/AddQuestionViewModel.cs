using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Admin
{
    public class AddQuestionViewModel
    {
        public AddQuestionViewModel()
        {
            AddedQuestions = new List<AddedQuestionRow>();
        }

        [Required]
        [Display(Name = "Test id")]
        public int TestId { get; set; }

        [Required]
        [Display(Name = "Questions")]
        public List<AddedQuestionRow> AddedQuestions { get; set; }
    }
}