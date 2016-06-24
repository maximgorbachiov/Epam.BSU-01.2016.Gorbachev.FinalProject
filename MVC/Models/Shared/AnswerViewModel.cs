using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Shared
{
    public class AnswerViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You don't enter text")]
        [Display(Name = "Answer text")]
        public string Text { get; set; }

        [Display(Name = "Number of answer")]
        public int Number { get; set; }
    }
}