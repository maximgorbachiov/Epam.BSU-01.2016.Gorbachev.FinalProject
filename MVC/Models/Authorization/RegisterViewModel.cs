using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        //[Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your surname")]
        public string Surname { get; set; }

        //[Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your patronymic")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "Enter your e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Enter your age")]
        public int Age { get; set; }
    }
}