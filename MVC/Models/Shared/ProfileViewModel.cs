using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Shared
{
    public class ProfileViewModel
    {
        public int ClientId { get; set; }

        [Display(Name = "Your name")]
        public string Name { get; set; }

        [Display(Name = "Your surname")]
        public string Surname { get; set; }

        [Display(Name = "Your patronymic")]
        public string Patronymic { get; set; }

        [Display(Name = "Your age")]
        public int Age { get; set; }

        [Display(Name = "Enter your e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}