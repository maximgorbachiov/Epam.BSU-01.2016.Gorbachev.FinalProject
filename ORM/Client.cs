using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<PassedTest> PassedTests { get; set; }

        public Client()
        {
            Roles = new HashSet<Role>();
            PassedTests = new HashSet<PassedTest>();
        }
    }
}
