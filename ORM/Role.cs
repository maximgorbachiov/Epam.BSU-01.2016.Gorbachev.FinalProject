using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Role()
        {
            Clients = new HashSet<Client>();
        }
    }
}
