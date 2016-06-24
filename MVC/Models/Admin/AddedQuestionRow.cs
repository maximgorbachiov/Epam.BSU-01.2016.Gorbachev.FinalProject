using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Admin
{
    public class AddedQuestionRow
    {
        [Required]
        public string Text { get; set; }

        public byte[] Image { get; set; }
    }
}