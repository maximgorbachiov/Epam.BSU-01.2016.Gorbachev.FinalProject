using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Admin
{
    public class RoleViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Role name")]
        public string Name { get; set; }
    }
}