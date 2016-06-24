using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int Number { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
