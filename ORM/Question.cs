using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string RightAnswer { get; set; }
        public byte[] Image { get; set; }

        public int TestId { get; set; }
        public virtual Test Test { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new HashSet<Answer>();
        }
    }
}
