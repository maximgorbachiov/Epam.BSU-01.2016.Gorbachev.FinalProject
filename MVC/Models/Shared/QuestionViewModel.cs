using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.Models.Shared
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Answers = new List<string>();
            Answers.Add("");
            Answers.Add("");
            Answers.Add("");
            Answers.Add("");
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You don't enter text to this field")]
        [Display(Name = "Question text")]
        public string QuestionText { get; set; }

        [Display(Name = "Right answer")]
        public string RightAnswer { get; set; }

        public int PrevQuestionId { get; set; }

        public int NextQuestionId { get; set; }

        public List<string> Answers { get; set; }

        public byte[] Image { get; set; }

        [Display(Name = "Test id")]
        public int TestId { get; set; }

        public int AnswerId { get; set; }

        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> NewAnswers { get; set; }
    }
}