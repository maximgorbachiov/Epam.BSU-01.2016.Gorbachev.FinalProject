using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ClientViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Client name")]
        public string Name { get; set; }

        [Display(Name = "Client surname")]
        public string Surname { get; set; }

        [Display(Name = "Client patronymic")]
        public string Patronymic { get; set; }

        [Display(Name = "Client e-mail")]
        public string Email { get; set; }

        [Display(Name = "Client age")]
        public int Age { get; set; }
    }
}