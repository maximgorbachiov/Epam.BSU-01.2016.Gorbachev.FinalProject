using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

        public Category()
        {
            Tests = new HashSet<Test>();
        }
    }
}
