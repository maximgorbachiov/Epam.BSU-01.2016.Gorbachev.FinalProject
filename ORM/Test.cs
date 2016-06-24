using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ORM
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? DateOfCreate { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<PassedTest> PassedTests { get; set; }

        public Test()
        {
            Questions = new HashSet<Question>();
            PassedTests = new HashSet<PassedTest>();
        }
    }
}
